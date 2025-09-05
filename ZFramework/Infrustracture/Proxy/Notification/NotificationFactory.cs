using Application.Service.Notification;
using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly ISmsGateway _smsGateway;
        private readonly IEmailProvider _emailProvider;

        public NotificationFactory(ISmsGateway smsGateway, IEmailProvider emailProvider)
        {
            _smsGateway = smsGateway;
            _emailProvider = emailProvider;
        }

        public INotificationCreator CreateSmsCreator(string phoneNumber)
        {
            return new SmsNotificationCreator(_smsGateway, phoneNumber);
        }

        public INotificationCreator CreateEmailCreator(string email)
        {
            return new EmailNotificationCreator(_emailProvider, email);
        }
    }
}
