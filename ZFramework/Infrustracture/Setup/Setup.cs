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
			services.AddDbContext<ApplicationDBContext>(options =>
			{
				options.UseSqlServer(appSettings.ConnectionStrings.SqlConnection.ToString());
			});

			services.AddScoped<IApplicationDBContext>(provider =>
				provider.GetRequiredService<ApplicationDBContext>());
		}
	}
}
