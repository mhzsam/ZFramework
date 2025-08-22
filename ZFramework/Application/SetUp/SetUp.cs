using Application.ApplicationService.AdminApplicationService;
using Application.ApplicationService.CommonApplicationService;
using Application.DTO.Role;
using Application.Service.Base;
using Application.Service.RoleService;
using Application.Service.UserService;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
namespace Application.SetUp
{
	public static class SetUp
	{
		public static void SetUpApplicationLayer(this IServiceCollection services, AppSettings appSettings)
		{
			AddAllApplicationServices(services);
			AddValidatorServices(services);
			AddDataAnnotationReturnData(services);
			AddCacheServices(services, appSettings.CacheSettings);



		}
		private static void AddAllApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ICommonApplicationService, CommonApplicationService>();
			services.AddScoped<IAdminApplicationService, AdminApplicationService>();

			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRoleService, RoleService>();

		}
		private static void AddValidatorServices(this IServiceCollection services)
		{
			services.AddValidatorsFromAssemblyContaining<RoleDtoValidator>();


		}
		public static void AddCacheServices(this IServiceCollection services, CacheSettings cacheSettings)
		{
			if (string.Equals(cacheSettings?.Provider, "Redis", StringComparison.OrdinalIgnoreCase))
			{
				services.AddStackExchangeRedisCache(options =>
				{
					options.Configuration = cacheSettings.RedisConfiguration
						?? throw new InvalidOperationException("RedisConfiguration is missing in CacheSettings.");
				});

				services.AddScoped<ICacheService>(sp =>
				{
					var distributedCache = sp.GetRequiredService<IDistributedCache>();
					return new RedisCacheService(distributedCache, cacheSettings.DefaultExpirationSeconds);
				});
			}
			else
			{
				services.AddMemoryCache();

				services.AddScoped<ICacheService>(sp =>
				{
					var memoryCache = sp.GetRequiredService<IMemoryCache>();
					return new MemoryCacheService(memoryCache, cacheSettings.DefaultExpirationSeconds);
				});
			}


		}
		private static void AddDataAnnotationReturnData(this IServiceCollection services)
		{
			services.Configure<ApiBehaviorOptions>(
			   options => options.InvalidModelStateResponseFactory = actionContext =>
			   {
				   var errorRecordList = actionContext.ModelState
				  .Where(modelError => modelError.Value.Errors.Count > 0)
				  .Select(modelError => new
				  {
					  ErrorField = modelError.Key,
					  ErrorDescription = modelError.Value.Errors.FirstOrDefault().ErrorMessage
				  }).ToList();

				   var model = ResponseModel.Fail(errorRecordList?.Select(s => s.ToString())?.ToList());


				   return new BadRequestObjectResult(model);
			   }
			   );

		}



	}
}
