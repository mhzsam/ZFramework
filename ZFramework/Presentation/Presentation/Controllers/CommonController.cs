using Application.DTO.Captcha;
using Application.DTO.ResponseModel;
using Application.Helper;
using Application.Service.ResponseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	[AllowAnonymous]
	public class CommonController : BaseController
	{
		public CommonController(IResponseService res) : base(res)
		{
		}

		[HttpGet]
		public RessponseModel GetCaptcha()
		{
			GetCaptchaModel captcha = CaptchaHelper.GetCaptcha();
			if (captcha == null || string.IsNullOrEmpty(captcha.Base64Image))
			{
				return responseGenerator.Fail(System.Net.HttpStatusCode.Conflict, "اشکال در پردازش");
			}
			return responseGenerator.Succssed(captcha);

		}

		[HttpPost]
		public RessponseModel ValidateCaptcha([FromBody] VaslidateCaptchaModel model)
		{
			if (CaptchaHelper.ValidateCaptcha(model))
				return responseGenerator.Succssed();
			return responseGenerator.Fail(System.Net.HttpStatusCode.NotFound, "کپچا صحیح نمی باشد  ");
		}


		[HttpPost]
		public RessponseModel ValidateCaptcha2(int id)
		{

			return responseGenerator.Fail(System.Net.HttpStatusCode.NotFound, "کپچا صحیح نمی باشد  ");
		}
	}
}
