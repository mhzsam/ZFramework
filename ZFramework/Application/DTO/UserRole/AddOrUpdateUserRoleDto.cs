using Application.DTO.Role;
using Domain.Helper;
using Domain.Shared.PersianFeildName;
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
				.NotEmpty().WithMessage(ValidationMessages.Required(PersianFeildName.UserRole.UserId))
				.Must(w => HashIdHelper.DecodeInt(w) != null).WithMessage(ValidationMessages.InvalidValue(PersianFeildName.UserRole.UserId));

			RuleFor(x => x.RoleId)
							.NotEmpty().WithMessage(ValidationMessages.Required(PersianFeildName.UserRole.RoleId))
							.Must(w => w > 0).WithMessage(ValidationMessages.MinValue(PersianFeildName.UserRole.RoleId, 1));

		}
	}
}
