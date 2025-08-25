using Application.DTO.Role;
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
		Task<ResponseModel<List<RoleDto>>> GetAllActiveRoleAsync(string? searchTitle);
		Task<ResponseModel<List<UserDto>>> GetAllUserAsync();
		Task<PagingResponseModel<UserDto>> GetPagedActiveUserAsync(QueryParameters queryParameters);
		Task<ResponseModel<GetUserRoleForModifyDto>> GetUserRoleForModifyAsync(string _userId);
	}
}
