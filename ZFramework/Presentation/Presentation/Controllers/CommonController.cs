using Application1.Helper;
using Domain1.Shared.Message;
using Domain1.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation1.Controllers
{
	[AllowAnonymous]
	public class CommonController : BaseController
	{


		[HttpGet]
		public ResponseModel<GetCaptchaModel> GetCaptcha()
		{
			GetCaptchaModel captcha = CaptchaHelper.GetCaptcha();
			if (captcha == null || string.IsNullOrEmpty(captcha.Base64Image))
			{
				return ResponseModel<GetCaptchaModel>.Fail(ErrorText.General.Failed);
			}
			return ResponseModel<GetCaptchaModel>.Success(captcha);

		}

		[HttpPost]
		public ResponseModel ValidateCaptcha([FromBody] VaslidateCaptchaModel model)
		{
			if (CaptchaHelper.ValidateCaptcha(model))
				return ResponseModel.Success();
			return ResponseModel.Fail(ErrorText.General.Failed);
		}


		[HttpPost]
		public ResponseModel ValidateCaptcha2(int id)
		{
			return ResponseModel.Fail(ErrorText.General.Failed);
		}
	}
}
