using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lifepaper.Models;
using Lifepaper.Data;
using Google.Apis.Auth;

namespace Lifepaper.Controllers
{
    public class UsersController : Controller
    {
        private readonly BaseContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(BaseContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            var user = _context.Usuarios.AsQueryable();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                user = user.Where(f => f.Nombre == username && f.Contraseña == password);
            }

            if (user.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }

        [HttpPost("GoogleSignIn")]
        public async Task<IActionResult> GoogleSignIn([FromBody] TokenRequest tokenRequest)
        {
            try
            {
                _logger.LogInformation("Token recibido: {Token}", tokenRequest.Token);

                // Validar el token recibido
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { "1071142487355-mp3rj6u4h7b7dscdq0ou904jddflc82j.apps.googleusercontent.com" }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenRequest.Token, settings);
                _logger.LogInformation("Token validado: {Email}", payload.Email);

                // Buscar o crear el usuario en la base de datos
                var user = _context.Usuarios.SingleOrDefault(u => u.Correo == payload.Email);

                if (user == null)
                {
                    user = new Usuario
                    {
                        Nombre = payload.GivenName,
                        Apellido = payload.FamilyName,
                        Correo = payload.Email,
                        GoogleId = payload.Subject
                    };
                    _context.Usuarios.Add(user);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Nuevo usuario creado: {Email}", payload.Email);
                }

                // Redirigir al usuario a la vista de bienvenida
                return Ok(new { success = true });
            }
            catch (InvalidJwtException ex)
            {
                _logger.LogError("Token inválido: {Message}", ex.Message);
                return BadRequest("Invalid Google token.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }




        public IActionResult Welcome()
        {
            return View();
        }

        public class TokenRequest
        {
            public string Token { get; set; }
        }
    }
}
