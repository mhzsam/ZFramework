using Application.Service.Base;
using Domain.Helper;
using Domain.Shared;
using System.Security.Claims;

namespace Presentation.Middleware
{
	public class CurrentUserMiddleware
	{
		private readonly RequestDelegate _next;

		public CurrentUserMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, ICurrentUserService currentUser)
		{
			if (context.User.Identity?.IsAuthenticated == true)
			{
				int? userId = context.User.FindFirst(StaticKey.GetUserClaimKey())?.ToString().ToInt();
				var roles = (context.User.FindFirst(StaticKey.GetUserRolesClaimKey()))?.ToString().Split(",").Select(s => s.ToInt()).ToList();

				currentUser.SetUser(userId, roles);
			}

			await _next(context);
		}
	}

}
