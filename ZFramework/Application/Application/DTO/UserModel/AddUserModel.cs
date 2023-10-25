using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserService
{
    
     public  class AddUserModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "نام الزامی است")]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "فامیلی الزامی است")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string? MobileNumber { get; set; }
        public string? NationalCode { get; set; }
        [EmailAddress(ErrorMessage ="فرمت ایمیل صحیح نیست ")]
        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string EmailAddress { get; set; }
      
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",
        ErrorMessage = "پسورد باید حداقل 8 حرف و شامل حروف و عدد باشد")]
        public string Password { get; set; }        
        
    }
}
