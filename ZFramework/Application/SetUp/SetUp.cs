using Application.Service.Base;
using Application.Service.UserService;
using Domain.Shared.Interface;
using Domain.Shared.Models;
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
			AddDataAnnotationReturnData(services);
			AddCatchServices(services, appSettings);



		}
		private static void AddAllApplicationServices(this IServiceCollection services)
		{
			
			services.AddScoped<IUserService, UserService>();

		}
		private static void AddCatchServices(this IServiceCollection services, AppSettings appSettings)
		{
			var cacheSettings = appSettings.CacheSettings ?? new CacheSettings();

			if (cacheSettings.Provider.Equals("Redis", StringComparison.OrdinalIgnoreCase))
			{
				// ۱) ثبت زیرساخت Redis
				services.AddStackExchangeRedisCache(options =>
				{
					options.Configuration = cacheSettings.RedisConfiguration;
				});

				// ۲) ثبت ICacheService برای Redis
				services.AddScoped<ICacheService>(sp =>
				{
					var distributedCache = sp.GetRequiredService<IDistributedCache>();
					return new RedisCacheService(distributedCache, cacheSettings.DefaultExpirationSeconds);
				});
			}
			else
			{
				// ۱) ثبت زیرساخت Memory
				services.AddMemoryCache();

				// ۲) ثبت ICacheService برای Memory
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
