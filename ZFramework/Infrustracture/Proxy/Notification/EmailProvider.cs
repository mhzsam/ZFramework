/*using Application.Service.Notification;
using Domain.Shared.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class EmailProvider : IEmailProvider
    {
        public async Task<bool> SendAsync(string email, string message)
        {
            try
            {
                // مشخصات فرستنده
                var fromAddress = new MailAddress("aida.radfard.1@gmail.com", "Z Framework");
                var toAddress = new MailAddress(email);
                const string fromPassword = "wgaa kfsd pxiz dbqj";
                const string subject = "پیام از زد فریمورک";

                // تنظیمات SMTP
                using var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587, // TLS
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                // ساخت ایمیل
                using var mail = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = false
                };

                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email send failed: {ex.Message}");
                return false;
            }
        }
    }
}
*/

using Application.Service.Notification;
using Domain.Shared.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Proxy.Notification
{
    public class EmailProvider : IEmailProvider
    {
        private readonly IConfiguration _configuration;

        public EmailProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendAsync(string email, string message)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");
                var fromEmail = emailSettings["FromEmail"];
                var fromName = emailSettings["FromName"];
                var fromPassword = emailSettings["AppPassword"];
                var smtpHost = emailSettings["SmtpHost"];
                var smtpPort = int.Parse(emailSettings["SmtpPort"]);
                var enableSsl = bool.Parse(emailSettings["EnableSsl"]);

                var fromAddress = new MailAddress(fromEmail, fromName);
                var toAddress = new MailAddress(email);
                const string subject = "ایمیل از زد فریمورک";

                using var smtp = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    EnableSsl = enableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using var mail = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = false
                };

                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email send failed: {ex.Message}");
                return false;
            }
        }
    }
}
