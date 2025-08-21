using Microsoft.AspNetCore.Builder;
using Presentation.Middleware;

namespace Presentation.SetUp
{
	public static class ApplicationBuilderExtensions
	{
		public static void UseAppMiddlewares(this WebApplication app)
		{
			app.UseCors();
			app.UseSwagger();
			app.UseSwaggerUI();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.UseMiddleware<ExceptionHandlingMiddleware>();
			app.UseMiddleware<PermissionControlMiddleware>();
			app.MapGet("/", context =>
			{
				context.Response.Redirect("/swagger");
				return Task.CompletedTask;
			});
		}
	}
}
