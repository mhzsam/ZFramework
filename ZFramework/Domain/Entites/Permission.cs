using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites.Base;
using Domain.Helper;

namespace Domain.Entites
{
    public class Permission : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "مقدار شناسه الزامی است ")]
        public int Id { get; set; }

        [MaxLength(32)]
        [Required(ErrorMessage = "مقدار نام پروژه الزامی است ")]
        public string ProjectName { get; set; }

        [MaxLength(32)]
        [Required(ErrorMessage = "مقدار نام کنترلر الزامی است ")]
        public string ControllerName { get; set; }

        [MaxLength(32)]
        [Required(ErrorMessage = "مقدار نام اکشن الزامی است ")]
        public string ActionName { get; set; }

        [MaxLength(32)]
        [Required(ErrorMessage = "مقدار نوع متد الزامی است ")]
        public string ActionMethod { get; set; }

		public ulong PermissionHash { get; set; }

		public string? Description { get; set; }

		public bool IsActivee { get; set; }

		public void ComputeAndSetHash()
		{
			var key = $"{ProjectName}&{ControllerName}&{ActionName}&{ActionMethod}".ToLowerInvariant();
			PermissionHash = PermissionHashHelper.ComputeHash(key);
		}
	}
}
