using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites.Base;

namespace Domain.Entites
{
    public class Permission: EntityClass
    {
       
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

    }
}
