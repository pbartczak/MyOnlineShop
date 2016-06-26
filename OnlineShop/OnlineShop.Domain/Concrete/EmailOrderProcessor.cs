using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using OnlineShop.Domain.Concrete;
using System.Web.Mail;
using OnlineShop.Domain.Abstract;

namespace OnlineShop.Domain.Entites.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmialSettings emailSettings;

        public EmailOrderProcessor(EmialSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShoppingDetails shippingInfo) 
        {
            emailSettings.MailToAddress = shippingInfo.Email;
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(emailSettings.Username, emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("Dziękujemy za zakupy!")
                    .AppendLine("----")
                    .AppendLine("Kupione produkty: ");
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Products.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (Koszt: {2:c})\n",
                        line.Quantity,
                        line.Products.Name,
                        subtotal);
                }

                body.AppendFormat("Zakupy na łączną kwotę: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("\n----")
                    .AppendLine("Dane: ")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("----")
                    .AppendFormat("Zapakowano jako prezent: {0}", shippingInfo.GifWrap ? "Yes" : "No");

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "Zakupiono produkty w Mój Sklep!",
                    body.ToString());
                
                // gdy próbujemy dużo razy to wkońcu serwer nie pozwala nam się zalogować i wyskakuje błąd 
                smtpClient.Send(mailMessage);
            }
        }
    }
}
