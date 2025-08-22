using Application.Service.Base;
using Domain.Helper;
using Domain.Shared.Enums;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

public class PermissionControlMiddleware
{
	private readonly RequestDelegate _next;
	private readonly AppSettings _appSettings;

	public PermissionControlMiddleware(RequestDelegate next, IOptions<AppSettings> options)
	{
		_next = next;
		_appSettings = options.Value;
	}

	public async Task Invoke(HttpContext context, ICurrentUserService currentUserService)
	{
		var endpoint = context.GetEndpoint();

		// اگه اکشن یا کنترلر AllowAnonymous باشه => رد شدن از Permission Check
		if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
		{
			await _next(context);
			return;
		}
		if (currentUserService?.Roles?.Count > 0 && currentUserService.Roles.Any(s => s == DefaultRole.SuperAdmin.ToInt()))
		{
			await _next(context);
			return;
		}

		if (context.User?.Identity?.IsAuthenticated != true)
			throw new UnauthorizedAccessException();

		// اطلاعات route
		var projectName = _appSettings.ProjectDetails.Title;
		var controllerName = context.GetRouteData().Values["controller"]?.ToString() + "Controller";
		var actionName = context.GetRouteData().Values["action"]?.ToString();
		var methodName = context.Request.Method;

		var requestKey = $"{projectName}&{controllerName}&{actionName}&{methodName}".ToLowerInvariant();
		var requestHash = PermissionHashHelper.ComputeHash(requestKey);

		// چک دسترسی از HashSet در حافظه
		if (!currentUserService.Permissions.Contains(requestHash))
			throw new UnauthorizedAccessException();

		await _next(context);
	}
}
