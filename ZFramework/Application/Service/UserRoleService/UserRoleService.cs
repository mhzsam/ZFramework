using Application.DTO.UserRole;
using Application.Helper;
using Application.Service.Base;
using Domain.Entites;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application.Service.UserRoleService
{
	public class UserRoleService : BaseService<UserRole>, IUserRoleService
	{

		public UserRoleService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUserRole) : base(applicationDBContext, currentUserRole)
		{


		}

	}
}
