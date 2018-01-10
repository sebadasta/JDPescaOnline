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
        public Task SendEmailAsync(string email, string subject, string message, List<EmailAddress> EmailList)
        {
            
            return Execute(subject, message, email, EmailList);
        }

        public Task Execute(string subject, string message, string email, List<EmailAddress> EmailList)
        {
           
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@jdpesca.com", "JDPesca"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };


            if(EmailList.Count == 0){
                
                msg.AddTo(new EmailAddress(email));

            }else{
                
                msg.AddTos(EmailList);
            }

            return client.SendEmailAsync(msg);
        }
    }
}
