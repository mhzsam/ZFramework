using Application.DTO.Role;
using Application.DTO.User;
using Domain.Helper;
using Domain.Shared.QueryableEngin;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserRole
{
	public class UserRoleDto
	{

		public int Id { get; set; }

		public int RoleId { get; set; }

		public RoleDto Role { get; set; }

		[JsonIgnore]
		public int UserId { get; set; }
		public string _UserId => HashIdHelper.Encode(UserId);

		
	}
}
