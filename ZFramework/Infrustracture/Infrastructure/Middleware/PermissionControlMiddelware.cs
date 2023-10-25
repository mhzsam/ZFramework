using Application.DTO.ResponseModel;
using Application.Helper;
using Application.Service.ResponseService;
using Domain.Context;
using Domain.Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.MiddleWare
{
    public static class PermissionControlMiddelware
    {
        public static IApplicationBuilder UsePermissionCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PermissionCheck>();
        }


    }

    internal class PermissionCheck
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IServiceScopeFactory _scopeFactory;



        public PermissionCheck(RequestDelegate next, IMemoryCache cache, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _cache = cache;
            _scopeFactory = scopeFactory;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            // 1 - if the request is not authenticated, nothing to do
            if (httpContext.User.Identity == null || !httpContext.User.Identity.IsAuthenticated)
            {
                await _next(httpContext);
                return;
            }

            var projectName = "Presentation";
            var controllerName = httpContext.Request.RouteValues["controller"]?.ToString() + "Controller";
            var actionName = httpContext.Request.RouteValues["action"]?.ToString();
            var methodName = httpContext.Request.Method;
            var requestPermission = (projectName + "&" + controllerName + "&" + actionName + "&" + methodName).ToLower();

            var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type == "userId").Value;

            var userPermission = (List<string>)_cache.Get("permission-" + userId);
            if (userPermission == null)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                    var role = await _dbContext.UserRols.AsNoTracking().Where(s => s.UserId.ToString() == userId).Select(s => s.RoleId).ToListAsync();
                    var rolePermission = await _dbContext.RolePermissions.AsNoTracking().Where(s => role.Contains(s.RoleId)).Select(s => s.PermissionId).ToListAsync();
                    userPermission = await _dbContext.Permissions.AsNoTracking().Where(s => rolePermission.Contains(s.Id)).Select(s => s.ProjectName + "&" + s.ControllerName + "&" + s.ActionName + "&" + s.ActionMethod).ToListAsync();


                }

                for (var i = 0; i < userPermission.Count; i++)
                {
                    userPermission[i] = userPermission[i].ToLower();
                }
                var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(120))
                                                             .SetSlidingExpiration(TimeSpan.FromMinutes(60));

                _cache.Set("permission-" + userId, userPermission, options);
            }
            if (!userPermission.Contains(requestPermission))
            {
                IResponseService responseService = httpContext.RequestServices.GetService<IResponseService>();
                var model = responseService.Fail(System.Net.HttpStatusCode.Unauthorized, ErrorText.Unauthorized);
                var json = JsonSerializer.Serialize(model);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync(json);
                return;
            };

            await _next(httpContext);
            return;
        }
    }
}
