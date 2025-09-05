using Application.ApplicationService.AdminApplicationService;
using Application.ApplicationService.CommonApplicationService;
using Application.ApplicationService.NotificationApplicationService;
using Application.Service.Base;
using Application.Service.Notification;
using Application.Service.PermissionService;
using Application.Service.RolePermissionService;
using Application.Service.RoleService;
using Application.Service.UserRoleService;
using Application.Service.UserService;
using DocumentFormat.OpenXml.InkML;
using Domain.Entites;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Infrastructure.Context;
using Infrastructure.Proxy.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SetUp
{
    public static class Setup
	{
		public static void SetUpInfrastructureLayer(this IServiceCollection services, AppSettings appSettings)
		{
			AddApplicationDBContext(services, appSettings);
            AddAllInfrastructureServices(services);
        }

		public static void AddApplicationDBContext(this IServiceCollection services, AppSettings appSettings)
		{
			services.AddDbContext<IApplicationDBContext,ApplicationDBContext>(options =>
			{
				options.UseSqlServer(appSettings.ConnectionStrings.SqlConnection);
			});

			
		}

        private static void AddAllInfrastructureServices(this IServiceCollection services)
        {
			services.AddScoped<ISmsGateway, SmsGateway>();
			services.AddScoped<IEmailProvider, EmailProvider>();
            services.AddScoped<INotificationFactory, NotificationFactory>();
        }
    }
}
