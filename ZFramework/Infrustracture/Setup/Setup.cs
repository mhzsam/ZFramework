using DocumentFormat.OpenXml.InkML;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SetUp
{
	public static class Setup
	{
		public static void SetUpInfrastructureLayer(this IServiceCollection services, AppSettings appSettings)
		{
			AddApplicationDBContext(services, appSettings);

		}

		public static void AddApplicationDBContext(this IServiceCollection services, AppSettings appSettings)
		{
			var tt = appSettings.ConnectionStrings.SqlConnection;
			services.AddDbContext<IApplicationDBContext, ApplicationDBContext>(options =>
			{
				options.UseSqlServer(appSettings.ConnectionStrings.SqlConnection);
			});
			using (var context = new ApplicationDBContext(
	new DbContextOptionsBuilder<ApplicationDBContext>()
		.UseSqlServer(appSettings.ConnectionStrings.SqlConnection)
		.Options))
			{
				try
				{
					var canConnect = context.Database.CanConnect();
					Console.WriteLine(canConnect
						? "✅ اتصال EF Core موفق بود!"
						: "❌ اتصال EF Core برقرار نشد.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("❌ خطا: " + ex.Message);
				}
			}
		}
	}
}
