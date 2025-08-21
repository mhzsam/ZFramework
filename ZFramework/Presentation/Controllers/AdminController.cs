using Application.ApplicationService.AdminApplicationService;
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
	public class AdminController : BaseController
	{

		private readonly IAdminApplicationService _adminApplicationService;
		public AdminController(IAdminApplicationService adminApplicationService)
		{
			_adminApplicationService = adminApplicationService;
		}

		[HttpGet]
		[Description(ControllerDescription.User.GetAll)]
		public async Task<ResponseModel<List<GetUserDto>>> GetAllUser()
		{
			return await _adminApplicationService.GetAllUserAsync();
		}


	}
}
