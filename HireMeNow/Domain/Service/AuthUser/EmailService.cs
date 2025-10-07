using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Domain.Helpers;
using Domain.Interface.AuthUser;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Domain.Service.AuthUser
{
    public class EmailService:IEmailService
    {
        private readonly MailSettings _mailSettings;
        
        public EmailService(IOptions<MailSettings> options)
        {
            
            this._mailSettings = options.Value;

        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Email);
                email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
               // using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
                throw; // optional: rethrow if you want the calling service to handle failures
            }
            //catch (Exception ex)
            //{
            //    // Better than Console.WriteLine for WebAPI
            //    // This will appear in ASP.NET Core's default logs
            //    Console.Error.WriteLine($"Email failed to {mailRequest.ToEmail}: {ex.Message}");
            //    throw;
            //}

        }
      

    }
}
