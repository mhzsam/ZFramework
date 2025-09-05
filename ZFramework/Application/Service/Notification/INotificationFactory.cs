using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Notification
{
    public interface INotificationFactory
    {
        INotificationCreator CreateSmsCreator(string phoneNumber);
        INotificationCreator CreateEmailCreator(string email);
    }
}
