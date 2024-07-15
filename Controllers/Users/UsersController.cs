using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lifepaper.Models;
using Microsoft.EntityFrameworkCore;
using Lifepaper.Data;

namespace Lifepaper.Controllers.Users
{
    public class UsersController : Controller
    {
        private readonly BaseContext _context;

        public UsersController(BaseContext context)
        {
            _context = context;
        }

        public IActionResult Signup()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
            user.FechaRegistro = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}