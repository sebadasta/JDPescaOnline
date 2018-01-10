using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JDPesca.Services;
using SendGrid.Helpers.Mail;

namespace JDPesca.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirma tu direccion de Email",
            $"Por favor confirma tu cuenta haciendo click <a href='{HtmlEncoder.Default.Encode(link)}'>en este link!</a>",null);
        }

        public static Task SendDeliverEmailAsync(this IEmailSender emailSender, string email,string Orden)
        {
            return emailSender.SendEmailAsync(email, "Cambio de estado de pedido: "+Orden,
        $"El estado de tu Orden #" +Orden + " cambio a Entregado!",null);
        }

        public static Task OrderCreatedEmailAsync(this IEmailSender emailSender, List<EmailAddress> emailList, string Orden)
        {
            return emailSender.SendEmailAsync(null, "Nueva orden creada: Orden #" + Orden,
          $"El estado de la Orden actualmente es [Pendiente]!" +
                                              "<br><br>"+
           "<a href= http://localhost:5000/Orders/Details/"+Orden+">Ver el detalle de la orden</a>",emailList);
        }
    }
}
