using Application.DTO.Role;
using Domain.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UserRole
{
	public class AddOrUpdateUserRoleDto
	{
		public string UserId { get; set; }
		public int RoleId { get; set; }
	}
	public class AddUserRoleDtoValidator : AbstractValidator<AddOrUpdateUserRoleDto>
	{
		public AddUserRoleDtoValidator()
		{
			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(ValidationMessages.Required("شناسه کاربر"))
				.Must(w => HashIdHelper.DecodeInt(w) != null).WithMessage(ValidationMessages.InvalidValue("شناسه کاربر"));

			RuleFor(x => x.RoleId)
							.NotEmpty().WithMessage(ValidationMessages.Required("شناسه نقش"))
							.Must(w => w > 0).WithMessage(ValidationMessages.MinValue("شناسه نقش", 1));

		}
	}
}
