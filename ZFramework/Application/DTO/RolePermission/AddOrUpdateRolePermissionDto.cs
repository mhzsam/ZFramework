using Application.DTO.UserRole;
using Domain.Shared.PersianFeildName;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.RolePermission
{
	public class AddOrUpdateRolePermissionDto
	{
		public int RoleId { get; set; }
		public int PermissionId { get; set; }
	}
	public class AddOrUpdateRolePermissionDtoValidator : AbstractValidator<AddOrUpdateRolePermissionDto>
	{
		public AddOrUpdateRolePermissionDtoValidator()
		{
			RuleFor(x => x.RoleId)
				.NotEmpty().WithMessage(ValidationMessages.Required(PersianFeildName.RolePermission.RoleId))
				.Must(w => w > 0).WithMessage(ValidationMessages.MinValue(PersianFeildName.RolePermission.RoleId, 1));

			RuleFor(x => x.PermissionId)
							.NotEmpty().WithMessage(ValidationMessages.Required(PersianFeildName.RolePermission.PermissionId))
							.Must(w => w > 0).WithMessage(ValidationMessages.MinValue(PersianFeildName.RolePermission.PermissionId, 1));

		}
	}
}
