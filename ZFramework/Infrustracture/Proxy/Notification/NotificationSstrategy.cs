using Domain.Shared.Enums;
using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class SmsNotificationStrategy : INotificationStrategy
    {
        private readonly ISmsGateway _smsGateway;
        private readonly string _phoneNumber;

        public SmsNotificationStrategy(ISmsGateway smsGateway, string phoneNumber)
        {
            _smsGateway = smsGateway;
            _phoneNumber = phoneNumber;
        }

        public void Send(string message)
        {
            _smsGateway.SendAsync(_phoneNumber, message).Wait();
        }
    }
    public class EmailNotificationStrategy : INotificationStrategy
    {
        private readonly IEmailProvider _emailProvider;
        private readonly string _email;

        public EmailNotificationStrategy(IEmailProvider emailProvider, string email)
        {
            _emailProvider = emailProvider;
            _email = email;
        }

        public void Send(string message)
        {
            _emailProvider.SendAsync(_email, message).Wait();
        }
    }

}
