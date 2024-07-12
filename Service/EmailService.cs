using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Lifepaper.Models;
using Lifepaper.Data;
using MailerSendApi;
using MailerSendApi.Models;

namespace Lifepaper.Services
{
    public class EmailService
    {
        private readonly MailerSendService _mailerSendService;
        private readonly BaseContext _context;

        public EmailService(BaseContext context, MailerSendService mailerSendService)
        {
            _context = context;
            _mailerSendService = mailerSendService;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            // Configurar el destinatario del correo
            var recipients = new List<Recipient>
            {
                new Recipient { Correo = to }
            };

            // Configurar el mensaje de correo
            var newEmail = new Email
            {
                
                Subject = subject,
                Text = body
            };

            // Enviar el correo electrónico
           
            try
            {
                string mailInfo = await _mailerSendService.SendEmail(newEmail);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to send email: {ex.Message}");
            }

            
          
           
              
            
        }
    }
}
