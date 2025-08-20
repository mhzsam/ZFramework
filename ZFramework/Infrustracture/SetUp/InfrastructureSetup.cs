using Domain.Shared.Interface;
using Domain.Shared.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SetUp
{
	public static class InfrastructureSetup
	{
		public static void SetUpInfrastructureLayer(this IServiceCollection services, AppSettings appSettings)
		{
			AddApplicationDBContext(services, appSettings);

		}

		public static void AddApplicationDBContext(this IServiceCollection services, AppSettings appSettings)
		{

			services.AddDbContext<IApplicationDBContext, ApplicationDBContext>(options =>
			{
				options.UseSqlServer(appSettings.ConnectionStrings.SqlConnection);
			});

		}
	}
}
