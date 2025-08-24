using Application.ApplicationService.AdminApplicationService;
using Application.DTO.Role;
using Application.DTO.User;
using Application.Service.Base;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
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
			return await _adminApplicationService.GetPagedActiveUserAsync(queryParameters);
		}

		[HttpPost]
		[Description(ControllerDescription.Role.AddOrUpdate)]
		public async Task<ResponseModel<RoleDto>> AddOrUpdateRole(RoleDto roleDto)
		{
			return await _adminApplicationService.AddOrUpdateRoleAsync(roleDto);
		}
		[HttpGet]
		[Description(ControllerDescription.Role.GetActive)]
		public async Task<ResponseModel<List<RoleDto>>> GetActiveRole(string? searchTitle)
		{
			return await _adminApplicationService.GetAllActiveRoleAsync(searchTitle);
		}
	}
}
