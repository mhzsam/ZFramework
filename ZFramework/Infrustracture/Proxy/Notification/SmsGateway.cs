using Application.Service.Notification;
using Domain.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class SmsGateway: ISmsGateway
    {
        public async Task<bool> SendAsync(string phoneNumber, string message)
        {
            try
            {
                // Actual email sending logic
                Console.WriteLine($"[SMS] {message}");
                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }

    }
}
