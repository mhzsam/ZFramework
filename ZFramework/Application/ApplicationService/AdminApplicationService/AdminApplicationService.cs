using Application.DTO.Role;
using Application.DTO.User;
using Application.Service.Base;
using Application.Service.RoleService;
using Application.Service.UserService;
using Domain.Entites;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public class AdminApplicationService : BaseApplicationService, IAdminApplicationService
	{
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
		public AdminApplicationService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser, IUserService userService, IRoleService roleService) : base(applicationDBContext, currentUser)
		{
			_userService = userService;
			_roleService = roleService;
		}


		public async Task<ResponseModel<List<UserDto>>> GetAllUserAsync()
		{
			List<User> lstUser = await _userService.GetAllAsync();
			if (lstUser == null)
				return ResponseModel<List<UserDto>>.Success();

			List<UserDto> result = lstUser.Adapt<List<UserDto>>();
			return ResponseModel<List<UserDto>>.Success(result);
		}
		public async Task<PagingResponseModel<UserDto>> GetPagedActiveUserAsync(QueryParameters queryParameters)
		{
			PagingResponseModel<User>? pagUser = await _userService.GetPagedAsync(queryParameters, o => o.Where(w => w.IsActive == true && w.IsDeleted == false).Include(i => i.UserRoles).ThenInclude(t => t.Role));
			if (pagUser == null)
				return PagingResponseModel<UserDto>.Success();
			var res = pagUser.MapTo<User, UserDto>();
			return res;
		}
		public async Task<ResponseModel<List<RoleDto>>> GetAllActiveRoleAsync(string? searchTitle)
		{
			IEnumerable<Role> enRole;

			if (string.IsNullOrEmpty(searchTitle))
				enRole = await _roleService.GetAllAsync();
			else
				enRole = await _roleService.FindAsync(f => f.RoleName.Contains(searchTitle)); // بهتره Contains باشه برای جستجوی جزئی

			var lstRoleDto = enRole.Adapt<List<RoleDto>>();

			return ResponseModel<List<RoleDto>>.Success(lstRoleDto);

		}
		public async Task<ResponseModel<RoleDto>> AddOrUpdateRoleAsync(RoleDto roleDto)
		{

			return await _roleService.AddOrUpdateRoleAsync(roleDto);
		}

	}
}
