using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserDto
{
	public class GetUserDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? MobileNumber { get; set; }
		public string? NationalCode { get; set; }
		public string? PhoneNumber { get; set; }

		public string? Avatar { get; set; }
		public string EmailAddress { get; set; }
		public string? Password { get; set; }

	}
}
