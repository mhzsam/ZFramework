using Domain.Helper;
using Domain.Shared;
using Domain.Shared.Interface;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Presentation.Middleware
{
	public class PermissionControlMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly AppSettings _appSettings;
		private readonly IServiceScopeFactory _scopeFactory;

		public PermissionControlMiddleware(RequestDelegate next, IOptions<AppSettings> options, IServiceScopeFactory scopeFactory)
		{
			_next = next;
			_appSettings = options.Value;
			_scopeFactory = scopeFactory;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			// اگر یوزر احراز هویت نشده بود، عبور کن
			if (httpContext.User?.Identity?.IsAuthenticated != true)
			{
				await _next(httpContext);
				return;
			}

			// استخراج اطلاعات مسیر و اکشن
			var projectName = _appSettings.ProjectDetails.Title;
			var controllerName = httpContext.GetRouteData().Values["controller"]?.ToString() + "Controller";
			var actionName = httpContext.GetRouteData().Values["action"]?.ToString();
			var methodName = httpContext.Request.Method;

			var requestKey =
				$"{projectName}&{controllerName}&{actionName}&{methodName}".ToLowerInvariant();

			ulong requestHash = PermissionHashHelper.ComputeHash(requestKey);

			var userId = httpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value;
			if (string.IsNullOrWhiteSpace(userId))
				throw new UnauthorizedAccessException();

			// ایجاد scope جدید برای دسترسی به Scoped serviceها
			using var scope = _scopeFactory.CreateScope();
			var cacheService = scope.ServiceProvider.GetRequiredService<ICacheService>();
			var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDBContext>();

			// تلاش برای خواندن از cache
			var userPermission = await cacheService.GetAsync<List<ulong>>(CachKey.GetPermissionKey(userId));
			if (userPermission == null)
			{
				// گرفتن مجوزهای کاربر از دیتابیس


				userPermission = await dbContext.UserRols
									   .Where(w => w.UserId.ToString() == userId)
									   .Include(s => s.Role)
									   	.ThenInclude(s => s.RolePermissions)
									   		.ThenInclude(s => s.Permission)
									   .SelectMany(urp => urp.Role.RolePermissions)
									   .Select(rp => rp.Permission.PermissionHash)
									   .ToListAsync();

				// ذخیره‌سازی در cache برای 2 ساعت
				var options = new DistributedCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromHours(2));
				await cacheService.SetAsync(CachKey.GetPermissionKey(userId), userPermission, options);
			}

			// بررسی وجود دسترسی
			if (!userPermission.Contains(requestHash))
				throw new UnauthorizedAccessException();

			await _next(httpContext);
		}
	}
}
