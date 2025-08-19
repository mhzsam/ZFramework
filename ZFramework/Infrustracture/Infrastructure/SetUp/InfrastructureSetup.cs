using Domain.Context;
using Domain.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SetUp
{
	public static class InfrastructureSetup
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
        public static void AddApplicationDBContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IApplicationDBContext,ApplicationDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

        }
    }
}
