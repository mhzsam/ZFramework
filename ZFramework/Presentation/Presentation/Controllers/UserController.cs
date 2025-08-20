using Application1.DTO.UserDto;
using Application1.Service.UserService;
using Domain1.Entites;
using Domain1.Shared.Message;
using Domain1.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation1.Controllers
{
	public class UserController : BaseController
	{

		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<ResponseModel<List<User>>> GetAll()
		{
			List<User> model = await _userService.GetAllAsync();

			return ResponseModel<List<User>>.Success(model);
		}

		[HttpPost]
		public async Task<ResponseModel<User>> SingUp(AddUserModel addUserModel)
		{
			User model = await _userService.SingUp(addUserModel);
			return ResponseModel<User>.Success(model);
		}
		[HttpPost]
		public async Task<ResponseModel<string>> Login(string email, string password)
		{
			var model = await _userService.Login(email, password);
			if (!model.result)
			{
				return ResponseModel<string>.Fail(ErrorText.General.NotFound);
			}
			return ResponseModel<string>.Success($"Bearer {model.token}");
		}
	}
}
