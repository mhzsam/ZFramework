using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class SmsNotificationCreator : INotificationCreator
    {
        private readonly ISmsGateway _smsGateway;
        private readonly string _phoneNumber;

        public SmsNotificationCreator(ISmsGateway smsGateway, string phoneNumber)
        {
            _smsGateway = smsGateway;
            _phoneNumber = phoneNumber;
        }

        public INotificationStrategy CreateNotification()
        {
            return new SmsNotificationStrategy(_smsGateway, _phoneNumber);
        }
    }

    public class EmailNotificationCreator : INotificationCreator
    {
        private readonly IEmailProvider _emailProvider;
        private readonly string _email;

        public EmailNotificationCreator(IEmailProvider emailProvider, string email)
        {
            _emailProvider = emailProvider;
            _email = email;
        }

        public INotificationStrategy CreateNotification()
        {
            return new EmailNotificationStrategy(_emailProvider, _email);
        }
    }

}
