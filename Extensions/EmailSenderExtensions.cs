using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JDPesca.Services;

namespace JDPesca.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirma tu direccion de Email",
                $"Por favor confirma tu cuenta haciendo click <a href='{HtmlEncoder.Default.Encode(link)}'>en este link!</a>");
        }

        public static Task SendDeliverEmailAsync(this IEmailSender emailSender, string email,string Orden)
        {
            return emailSender.SendEmailAsync(email, "Cambio de estado de pedido: "+Orden,
               $"El estado de tu Orden #" +Orden + " cambio a Entregado!");
        }
    }
}
