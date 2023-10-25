using Domain.Context;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Presentation.Controllers;
using System.Reflection;

namespace Presentation.SetUp
{
    public static class AuthorizationSeedData
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ZApplication",
                    Version = "1",

                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "Bearer",
                    Name = "Authorization",

                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });

            });

            return services;
        }
        public static void AuthorizationControllerSeedData(ApplicationDBContext context, Assembly assembly)
        {

            var projectName = assembly.FullName.Split(",")[0];


            var controlleractionlist = assembly.GetTypes()
            .Where(type => typeof(BaseController).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Select(x => new
            {
                Controller = x.DeclaringType.Name,
                Action = x.Name,
                ActionMethod = x.GetCustomAttributes().Where(attr =>
            attr.GetType() == typeof(HttpGetAttribute)
            || attr.GetType() == typeof(HttpPutAttribute)
            || attr.GetType() == typeof(HttpPostAttribute)
            || attr.GetType() == typeof(HttpDeleteAttribute)
            ).FirstOrDefault().ToString().Split(".").LastOrDefault().Replace("Http", "").Replace("Attribute", "")
            })
            .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            List<Permission> pr = new List<Permission>();
            pr = context.Permissions.AsNoTracking().ToList();
            controlleractionlist.ForEach(p =>
            {

                if (!pr.Any(s => s.ProjectName == projectName &&
                                s.ControllerName == p.Controller &&
                                s.ActionName == p.Action &&
                                s.ActionMethod == p.ActionMethod
                             ))
                {
                    context.Permissions.Add(new Permission
                    {
                        ProjectName = projectName,
                        ControllerName = p.Controller,
                        ActionName = p.Action,
                        ActionMethod = p.ActionMethod
                    });
                }
            });

            pr.ForEach(p =>
            {
                if (!controlleractionlist.Any(s => p.ProjectName == projectName &&
                               p.ControllerName == s.Controller &&
                               p.ActionName == s.Action &&
                               p.ActionMethod == s.ActionMethod
                            ))
                {
                    var tt = new Permission
                    {
                        Id = p.Id,
                        ProjectName = projectName,
                        ControllerName = p.ControllerName,
                        ActionName = p.ActionName,
                        ActionMethod = p.ActionMethod
                    };

                    context.Permissions.Attach(tt);
                    context.Permissions.Remove(tt);

                }
            });

            context.SaveChanges();
        }
    }
}
