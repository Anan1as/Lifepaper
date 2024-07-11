using System.Threading.Tasks;
using Lifepaper.Data;
using Lifepaper.Models;
using Lifepaper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lifepaper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperacionContraseñaApiController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly EmailService _emailService;

        public RecuperacionContraseñaApiController(BaseContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("enviarCorreoRecuperacion")]
        public async Task<IActionResult> EnviarCorreoRecuperacion([FromBody] RecuperacionContraseñaRequest request)
        {
            if (string.IsNullOrEmpty(request.Correo))
            {
                return BadRequest("El correo electrónico es requerido.");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == request.Correo);
            if (usuario == null)
            {
                return NotFound("No se encontró un usuario con este correo.");
            }

            var emailSubject = "Recuperación de contraseña";
            var emailBody = $"Su contraseña es: {usuario.Contraseña}"; // ¡No recomendado en producción!
            await _emailService.SendAsync(request.Correo, emailSubject, emailBody);

            return Ok("Correo enviado con éxito.");
        }
    }
}
