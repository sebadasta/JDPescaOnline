using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace JDPesca.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, List<EmailAddress> EmailList);
    }
}
