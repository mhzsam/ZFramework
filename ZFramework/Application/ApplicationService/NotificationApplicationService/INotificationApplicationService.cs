using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Shared.Enums;
using Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.NotificationApplicationService
{
    public interface INotificationApplicationService
    {
        Task<ResponseModel> SendEmailAsync(string email, string template, Dictionary<string, string> parameters);
        Task<ResponseModel> SendSmsAsync(string phoneNumber, string template, Dictionary<string, string> parameters);
    }
}
