using Application.DTO.Permission;
using Application.Helper;
using Application.Service.Base;
using Application.Service.RoleService;
using Domain.Entites;
using Domain.Exception;
using Domain.Helper;
using Domain.Shared.Interface;
using Domain.Shared.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

namespace Application.Service.PermissionService
{
	public class PermissionService : BaseService<Permission>, IPermissionService
	{
		public PermissionService(IApplicationDBContext applicationDBContext, ICurrentUserService currentUser) : base(applicationDBContext, currentUser)
		{
		}
	}
}
