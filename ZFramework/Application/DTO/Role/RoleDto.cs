using Domain.Entites;
using Domain.Shared.QueryableEngin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Role
{
	public class RoleDto
	{		
		public int Id { get; set; }		
		public string RoleName { get; set; }		
		public bool IsActive { get; set; }
		
	}
}
