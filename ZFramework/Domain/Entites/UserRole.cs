using Domain.Entites.Base;
using Domain.Shared.QueryableEngin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
	public class UserRole : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required(ErrorMessage = "مقدار شناسه الزامی است ")]
		[Queryable]
		public int Id { get; set; }
		[Queryable]
		public int RoleId { get; set; }
		[Queryable]
		public Role Role { get; set; }
		[Queryable]
		public int UserId { get; set; }
		[Queryable]
		public User user { get; set; }


	}
}
