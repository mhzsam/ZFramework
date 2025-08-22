using Application.DTO.Role;
using Application.Service.Base;
using Domain.Entites;
using Domain.Shared.Models;

namespace Application.Service.RoleService
{
	public interface IRoleService : IBaseService<Role>
	{
		Task<ResponseModel<RoleDto>> AddOrUpdateRoleAsync(RoleDto roleDto);
	}
}
