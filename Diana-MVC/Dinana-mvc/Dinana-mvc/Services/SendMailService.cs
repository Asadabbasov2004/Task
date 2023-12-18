using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Net.Mail;

namespace Dinana_mvc.Services
{
    public class SendMailService
    {
        private readonly UserManager<AppUser> _userManager;

        public SendMailService(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        public async void SendEmail(string to, string name)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("asad007006@gmail.com", "token");
                client.EnableSsl = true;
              //  var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress("asad007006@gmail.com"),
                    Subject = "Welcome",
                    Body = $"<h1>Welcome to my website, dear {name} </h1>",
                    IsBodyHtml = true
                };
                mailMessage.To.Add(to);

                client.Send(mailMessage);

            }
        }

    }
}
