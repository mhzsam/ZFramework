using Domain.Entites.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class Role: EntityClass
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "مقدار نقش الزامی است ")]
        [MaxLength(32)]
        public string RoleName { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
