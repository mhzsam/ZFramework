using Application.ApplicationService.AdminApplicationService;
using Application.DTO.User;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
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

		[HttpPost]
		[Description(ControllerDescription.User.GetAll)]
		public async Task<PagingResponseModel<UserDto>> GetAllUser(QueryParameters queryParameters)
		{
			return await _adminApplicationService.GetPagedUserAsync(queryParameters);
		}


	}
}
