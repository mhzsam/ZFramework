using Application.DTO.UserDto;
using Application.Helper;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Presentation.Controllers
{
	[AllowAnonymous]
	public class CommonController : BaseController
	{


		[HttpGet]
		[Description(ControllerDescription.Common.GetCaptcha)]	
		
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
		[Description(ControllerDescription.Common.ValidateCaptcha)]

		public ResponseModel ValidateCaptcha([FromBody] VaslidateCaptchaModel model)
		{
			if (CaptchaHelper.ValidateCaptcha(model))
				return ResponseModel.Success();
			return ResponseModel.Fail(ErrorText.General.Failed);
		}
		//[HttpPost]
		//[Description(ControllerDescription.Common.SignUp)]
		//public async Task<ResponseModel<User>> SingUp(AddUserModel addUserModel)
		//{
		//	User model = await _userService.SingUp(addUserModel);
		//	return ResponseModel<User>.Success(model);
		//}
		//[HttpPost]
		//[Description(ControllerDescription.Common.Login)]
		//public async Task<ResponseModel<string>> Login(string email, string password)
		//{
		//	var model = await _userService.Login(email, password);
		//	if (!model.result)
		//	{
		//		return ResponseModel<string>.Fail(ErrorText.General.NotFound);
		//	}
		//	return ResponseModel<string>.Success($"Bearer {model.token}");
		//}
	}
}
