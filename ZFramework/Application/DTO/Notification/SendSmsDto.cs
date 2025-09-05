using Domain.Shared.PersianFeildName;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Notification
{
    public class SendSmsDto
    {
        public string Recipient { get; set; }
        public string Template { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }


    public class SendSmsDtoValidator : AbstractValidator<SendSmsDto>
    {
        public SendSmsDtoValidator()
        {
            var phoneRegex = new System.Text.RegularExpressions.Regex(@"(^\+?[1-9]\d{1,14}$)|(^09\d{9}$)");

            RuleFor(x => x.Recipient)
             .Cascade(CascadeMode.Stop)
             .Must(p => string.IsNullOrWhiteSpace(p) || phoneRegex.IsMatch(p))
             .WithMessage(ValidationMessages.Matches(
                                        PersianFeildName.Notification.Recipient,
                                        @"(^\+?[1-9]\d{1,14}$)|(^09\d{9}$)"));

            RuleFor(x => x.Template)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage(ValidationMessages.NotEmpty(PersianFeildName.Notification.Template));
            
            RuleFor(x => x.Parameters)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty(PersianFeildName.Notification.Parameters));

        }
    }
}
