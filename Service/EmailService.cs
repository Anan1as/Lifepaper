using System.Collections.Generic;
using System.Threading.Tasks;
using MailerSend;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Lifepaper.Models;
using System.Threading.Tasks;
using MailerSend.AspNetCore;

namespace Lifepaper.Services
{
    public class EmailService
    {
        private readonly MailerSendService _mailerSend;

        public EmailService(MailerSendService mailerSend)
        {
            _mailerSend = mailerSend;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var recipients = new List<Recipient>
            {
                new Recipient(to)
            };

            var email = new Email.Builder()
                .From("mail@domain.com")
                .Subject(subject)
                .Text(body)
                .To(recipients)
                .Build();

            await _mailerSend.SendEmailAsync(email);
        }
    }
}
