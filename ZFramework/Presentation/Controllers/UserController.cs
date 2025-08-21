using Application.DTO.UserDto;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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
		[Description(ControllerDescription.User.GetAll )]

		public async Task<ResponseModel<List<User>>> GetAll()
		{
			List<User> model = await _userService.GetAllAsync();

			return ResponseModel<List<User>>.Success(model);
		}

		
	}
}
