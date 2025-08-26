using Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Permission
{
	public class PermissionDto
	{

		public int Id { get; set; }

		public string ProjectName { get; set; }

		public string ControllerName { get; set; }

		public string ActionName { get; set; }

		public string ActionMethod { get; set; }

		public ulong PermissionHash { get; set; }

		public string? Description { get; set; }

		public bool IsActive { get; set; }

	}
}
