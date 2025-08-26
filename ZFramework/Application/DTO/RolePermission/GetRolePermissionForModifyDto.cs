using Application.DTO.Permission;
using Application.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.RolePermission
{
	public class GetRolePermissionForModifyDto
	{
		public PermissionDto? Permission { get; set; }
		public List<RoleDto>? AssignedRoles { get; set; }
		public List<RoleDto>? AvailableRoles { get; set; }
	}
}
