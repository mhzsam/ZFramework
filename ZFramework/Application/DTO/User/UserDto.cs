using Application.DTO.UserRole;
using Domain.Entites;
using Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Application.DTO.User
{
	public class UserDto
	{
		[JsonIgnore]
		public int Id { get; set; }
		public string _Id => HashIdHelper.Encode(Id);

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? MobileNumber { get; set; }
		public string? NationalCode { get; set; }
		public string? PhoneNumber { get; set; }

		public string? Avatar { get; set; }
		public string EmailAddress { get; set; }
		public string? Password { get; set; }
		public List<UserRoleDto> UserRoles { get; set; }

	}
}
