using Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        [MaxLength(100)]
        [Required(ErrorMessage ="نام الزامی است")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "فامیلی الزامی است")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string? MobileNumber { get; set; }
        public string? NationalCode { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Avatar { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = " ایمیل الزامی است")]
        public string EmailAddress { get; set; }
        public string? Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        [DefaultValue(false)]
        public bool ForceChanePassword { get; set; }
        public string? Token { get; set; }




    }
}
