using Application.Service.Base;
using Application.Service.Notification;
using Domain.Shared.Enums;
using Domain.Shared.Interface;
using Domain.Shared.Message;
using Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationService.NotificationApplicationService
{
    public class NotificationApplicationService: BaseApplicationService,INotificationApplicationService
    {
        private readonly INotificationFactory _notificationFactory;

        public NotificationApplicationService(
            IApplicationDBContext applicationDBContext,
            ICurrentUserService currentUserService,
            INotificationFactory notificationFactory)
            : base(applicationDBContext, currentUserService)
        {
            _notificationFactory = notificationFactory;
        }
        public async Task<ResponseModel> SendSmsAsync(string phoneNumber, string template, Dictionary<string, string> parameters)
        {
            var creator = _notificationFactory.CreateSmsCreator(phoneNumber);
            var notification = creator.CreateNotification();

            var message = new NotificationTemplate(template).Render(parameters);
            notification.Send(message);

            return ResponseModel.Success();
        }

        public async Task<ResponseModel> SendEmailAsync(string email, string template, Dictionary<string, string> parameters)
        {
            var creator = _notificationFactory.CreateEmailCreator(email);
            var notification = creator.CreateNotification();

            var message = new NotificationTemplate(template).Render(parameters);
            notification.Send(message);

            return ResponseModel.Success();
        }


    }
}
