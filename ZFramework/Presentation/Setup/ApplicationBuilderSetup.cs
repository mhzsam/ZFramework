using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

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
			app.UsePermissionCheck();
			app.UseMiddleware<ExceptionHandlingMiddleware>();
			app.MapGet("/", context =>
			{
				context.Response.Redirect("/swagger");
				return Task.CompletedTask;
			});
		}
	}
}
