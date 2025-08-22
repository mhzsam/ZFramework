using Application.Service.Base;
using Domain.Shared.Interface;
using Domain.Shared;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;
using Domain.Helper;

public class CurrentUserMiddleware
{
	private readonly RequestDelegate _next;

	public CurrentUserMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context, ICurrentUserService currentUserService, ICacheService cacheService, IApplicationDBContext dbContext)
	{
		if (context.User?.Identity?.IsAuthenticated != true)
		{
			await _next(context);
			return;
		}

		var userId = context.User.Claims.FirstOrDefault(c => c.Type == StaticKey.GetUserClaimKey())?.Value;
		if (string.IsNullOrEmpty(userId))
		{
			await _next(context);
			return;
		}

		var permissions = await cacheService.GetAsync<HashSet<ulong>>(StaticKey.GetPermissionKey(userId));
		if (permissions == null)
		{
			permissions = (await dbContext.UserRols
				.Where(w => w.UserId.ToString() == userId)
				.Include(r => r.Role)
					.ThenInclude(r => r.RolePermissions)
						.ThenInclude(rp => rp.Permission)
				.SelectMany(urp => urp.Role.RolePermissions)
				.Select(rp => rp.Permission.PermissionHash)
				.ToListAsync())
				.ToHashSet();

			await cacheService.SetAsync(
				StaticKey.GetPermissionKey(userId),
				permissions,
				new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(2))
			);
		}
		var lstUserRole = context.User.Claims.Where(c => c.Type == StaticKey.GetUserRolesClaimKey())?
										     .Select(s=>s.Value.ToInt())?
											 .ToList();

		currentUserService.SetUser(userId.ToInt(), permissions, lstUserRole);

		await _next(context);
	}
}
