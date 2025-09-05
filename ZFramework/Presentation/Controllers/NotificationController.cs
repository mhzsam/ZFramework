using Application.ApplicationService.CommonApplicationService;
using Application.ApplicationService.NotificationApplicationService;
using Application.DTO.Notification;
using Application.DTO.Role;
using Application.DTO.User;
using Domain.Shared.Models;
using Domain.Shared.QueryableEngin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Presentation.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
        private readonly INotificationApplicationService _notificationApplicationService;
        public NotificationController(INotificationApplicationService notificationApplicationService)
        {
            _notificationApplicationService = notificationApplicationService;
        }

        [HttpPost]
        [Description(ControllerDescription.Notification.SendSms)]
        public async Task<ResponseModel> SendSms([FromBody] SendSmsDto sendSmsDto)
        {
            return await _notificationApplicationService.
                SendSmsAsync(sendSmsDto.Recipient, sendSmsDto.Template, sendSmsDto.Parameters);
        }

        [HttpPost]
        [Description(ControllerDescription.Notification.SendEmail)]
        public async Task<ResponseModel> SendEmail([FromBody] SendEmailDto sendEmailDto)
        {
            return await _notificationApplicationService.
                           SendEmailAsync(sendEmailDto.Recipient, sendEmailDto.Template, sendEmailDto.Parameters);
        }
    }
}
