using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailerSend;
using MailerSend.Models;

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

            var email = new Email
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

            var response = await _mailerSend.Email.SendAsync(email);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"Failed to send email: {errorMessage}");
            }
        }
    }
}
