using Application.DTO.Role;
using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserRole
{
	public class GetUserRoleForModifyDto
	{
		public UserDto User { get; set; }
		public List<RoleDto>? AssignedRoles { get; set; }
		public List<RoleDto>? AvailableRoles { get; set; }
	}
}
