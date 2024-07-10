using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailerSend;
using MailerSend.Models;
using Lifepaper.Models;
 // Asegúrate de tener esta directiva para los modelos de MailerSend


namespace Lifepaper.Services
{
    public class EmailService
    {
        private readonly MailerSend.AspNetCore.MailerSendService _mailerSend;

        public EmailService(MailerSend.AspNetCore.MailerSendService mailerSend)
        {
            _mailerSend = mailerSend;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var recipient = new Recipient(to);

            var correo = new Correo
            {
                From = new From
                {
                    Email = "yeifry.121@gmail.com",
                    Name = "Yeifry Leandro"
                },
                To = new List<Recipient> { recipient },
                Subject = subject,
                Text = body
            };

            var response = await _mailerSend.Correo.SendAsync(email);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to send email: {errorMessage}");
            }
        }
    }
}
