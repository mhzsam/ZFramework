using Application.DTO.RolePermission;
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

namespace Application.Service.RolePermissionService
{
	public class RolePermissionService : BaseService<RolePermission>, IRolePermissionService
	{

		public RolePermissionService(IApplicationDBContext applicationDBContext, ICurrentUserService currentRolePermission) : base(applicationDBContext, currentRolePermission)
		{
		}
	}
}
