using Application.DTO.UserDto;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
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
