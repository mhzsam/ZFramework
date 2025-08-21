using Application.DTO.UserDto;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Presentation.Controllers
{
	[Authorize]
	public class UserController : BaseController
	{

		private readonly IUserService _userService;
		private readonly ICurrentUserService _currentUserService;
		public UserController(IUserService userService, ICurrentUserService currentUserService)
		{
			_userService = userService;
			_currentUserService = currentUserService;
		}

		[HttpGet]
		[Description(ControllerDescription.User.GetAll)]
		public async Task<ResponseModel<List<User>>> GetAll()
		{
			var ff = _currentUserService.UserId;
			var ff2 = _currentUserService.Roles;
			List<User> model = await _userService.GetAllAsync();

			return ResponseModel<List<User>>.Success(model);
		}


	}
}
