using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Lifepaper.Data;
using Microsoft.Extensions.Options;
using Lifepaper.Models;

namespace Lifepaper.Services
{
    public class EmailService
    {
        private readonly BaseContext _context;
        private readonly SmtpSettings _smtpSettings;

        public EmailService(BaseContext context, IOptions<SmtpSettings> smtpSettings)
        {
            _context = context;
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.From = new MailAddress(_smtpSettings.Username);
                    message.To.Add(new MailAddress(to));
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = false;

                    await client.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to send email: {ex.Message}");
            }
        }
    }
}
