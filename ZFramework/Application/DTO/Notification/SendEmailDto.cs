using Domain.Shared.PersianFeildName;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Notification
{
    public class SendEmailDto
    {
        public string Recipient { get; set; }
        public string Template { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }


    public class SendEmailDtoValidator : AbstractValidator<SendEmailDto>
    {
        public SendEmailDtoValidator()
        {
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

            RuleFor(x => x.Recipient)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(ValidationMessages.Required(PersianFeildName.Notification.Recipient))
            .Must(p => string.IsNullOrWhiteSpace(p) || emailRegex.IsMatch(p))
            .WithMessage(ValidationMessages.Matches(
                                        PersianFeildName.Notification.Recipient,
                                        @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"));

            RuleFor(x => x.Template)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage(ValidationMessages.NotEmpty(PersianFeildName.Notification.Template));

            RuleFor(x => x.Parameters)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty(PersianFeildName.Notification.Parameters));

        }
    }
}
