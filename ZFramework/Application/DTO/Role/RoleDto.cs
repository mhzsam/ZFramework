using Domain.Entites;
using Domain.Shared.Message;
using Domain.Shared.QueryableEngin;
using FluentValidation;
using Microsoft.IdentityModel.Tokens.Experimental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Role
{
	public class RoleDto
	{
		public int Id { get; set; }
		public string RoleName { get; set; }
		public bool IsActive { get; set; }

	}
	public class RoleDtoValidator : AbstractValidator<RoleDto>
	{
		public RoleDtoValidator()
		{
			RuleFor(x => x.RoleName)
				.NotEmpty().WithMessage(ValidationMessages.Required("نام نقش"))
				.MaximumLength(100).WithMessage(ValidationMessages.MaxLength("نام نقش", 100))
				.MinimumLength(5).WithMessage(ValidationMessages.MinLength("نام نقش", 5));
		}
	}
}
