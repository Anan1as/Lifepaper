using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lifepaper.Models;
using Lifepaper.Data;

namespace Lifepaper.Controllers
{
    public class UsersController : Controller
    {
        private readonly BaseContext _context;

        public UsersController(BaseContext context)
        {
            _context = context;
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
    }
}
