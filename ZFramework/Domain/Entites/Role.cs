
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
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "مقدار نقش الزامی است ")]
        [MaxLength(32)]
		[Queryable]
		public string RoleName { get; set; }
        [DefaultValue(true)]
		[Queryable]
		public bool IsActive { get; set; }

		public List<RolePermission> RolePermissions { get; set; }

	}
}
