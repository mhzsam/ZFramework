
using Domain.Entites.Base;
using Domain.Shared.QueryableEngin;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
	public class Role : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required(ErrorMessage = "مقدار شناسه الزامی است ")]
		[Queryable]

		public int Id { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required(ErrorMessage = "مقدار نقش الزامی است ")]
		[MaxLength(32)]

		public string RoleName { get; set; }
		[DefaultValue(true)]

		public bool IsActive { get; set; }

		public List<RolePermission> RolePermissions { get; set; }

	}
}
