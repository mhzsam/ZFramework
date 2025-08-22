using Application.ApplicationService.CommonApplicationService;
using Application.DTO.User;
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
		private readonly ICommonApplicationService _commonApplicationService;

		public CommonController(ICommonApplicationService commonApplicationService)
		{
			_commonApplicationService = commonApplicationService;
		}

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

		[HttpPost]
		[Description(ControllerDescription.Common.SignUp)]
		public async Task<ResponseModel<UserDto>> SingUp(AddUserModel addUserModel)
		{
			return await _commonApplicationService.SingUp(addUserModel);
		}

		[HttpPost]
		[Description(ControllerDescription.Common.Login)]
		public async Task<ResponseModel<string>> Login(string mobile, string password)
		{
			return await _commonApplicationService.Login(mobile, password);
		}
	}
}
