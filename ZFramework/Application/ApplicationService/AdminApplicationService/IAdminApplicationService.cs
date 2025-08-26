using Application.DTO.Permission;
using Application.DTO.Role;
using Application.DTO.RolePermission;
using Application.DTO.User;
using Application.DTO.UserRole;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.AdminApplicationService
{
	public interface IAdminApplicationService
	{
		Task<ResponseModel<RoleDto>> AddOrUpdateRoleAsync(RoleDto roleDto);
		Task<ResponseModel> AddOrUpdateUserRoleAsync(AddOrUpdateUserRoleDto addOrUpdateUserRoleDto);
		Task<ResponseModel<List<RoleDto>>> GetAllActiveRoleAsync(string? searchTitle);
		Task<ResponseModel<List<UserDto>>> GetAllUserAsync();
		Task<PagingResponseModel<PermissionDto>> GetPagedActivePermissionAsync(QueryParameters queryParameters);
		Task<PagingResponseModel<UserDto>> GetPagedActiveUserAsync(QueryParameters queryParameters);
		Task<ResponseModel<GetRolePermissionForModifyDto>> GetRolePermissionForModifyAsync(int permissionId);
		Task<ResponseModel> AddOrUpdateRolePermissionAsync(AddOrUpdateRolePermissionDto model);
		Task<ResponseModel<GetUserRoleForModifyDto>> GetUserRoleForModifyAsync(string _userId);
	}
}
