using DocumentFormat.OpenXml.InkML;
using Domain.Entites;
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
			services.AddDbContext<IApplicationDBContext,AplicationDBContext>(options =>
			{
				options.UseSqlServer("Server=localhost,1433;Database=ZFramework;User Id=sa;Password=Zarrabi12345678!;TrustServerCertificate=True;");
			});

			
		}
	}
}
