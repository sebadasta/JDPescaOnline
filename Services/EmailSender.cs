using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace JDPesca.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@jdpesca.com", "JDPesca"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
