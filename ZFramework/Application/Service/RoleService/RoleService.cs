using Application.DTO.Role;
using Application.Helper;
using Application.Service.Base;
using Domain.Entites;
using Domain.Exception;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace Application.Service.RoleService
{
	public class RoleService : BaseService<Role>, IRoleService
	{

		public RoleService(IApplicationDBContext applicationDBContext, ICurrentUserService currentRole) : base(applicationDBContext, currentRole)
		{
		}
		public async Task<ResponseModel<RoleDto>> AddOrUpdateRoleAsync(RoleDto roleDto)
		{
			if (_currentUser.UserId == default)
				throw new UnauthorizedAccessException();

			Role? role;
			if (roleDto.Id == default)
			{
				role = roleDto.Adapt<Role>();
				role.InsertBy = _currentUser.UserId.Value;
				role.InsertDate = DateTime.Now;
				_dbSet.Add(role);
			}
			else
			{
				role = await GetByIdAsync(roleDto.Id);
				if (role == null)
					throw new CustomException(ValidationMessages.NotFound("نقش"));


				role.RoleName = roleDto.RoleName;
				role.UpdateBy = _currentUser.UserId.Value;
				role.UpdateDate = DateTime.Now;

			}
			await SaveChangesAsync();
			return ResponseModel<RoleDto>.Success(role.Adapt<RoleDto>());
		}
	}
}
