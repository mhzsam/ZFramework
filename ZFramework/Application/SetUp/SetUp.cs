using Application.Service.UserService;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application.SetUp
{
	public static class SetUp
	{
		public static void SetUpApplicationLayer(this IServiceCollection services, AppSettings appSettings)
		{
			AddAllApplicationServices(services);
			AddDataAnnotationReturnData(services);
		

		}
		private static void AddAllApplicationServices(this IServiceCollection services)
		{
			services.AddMemoryCache();
			services.AddScoped<IUserService, UserService>();

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
