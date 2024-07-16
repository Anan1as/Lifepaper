using Microsoft.AspNetCore.Mvc;
using Lifepaper.Data;
using Lifepaper.Models;

namespace Lifepaper.Controllers;

public class UsersController : Controller
{
    public readonly BaseContext _context;

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
        return RedirectToAction("Privacy", "Home");
    }

    public IActionResult SignIn(string username, string password)
    {
        var user = _context.Usuarios.FirstOrDefault(f => f.Nombre == username && f.Contraseña == password);
        if (user != null)
        {
            return RedirectToAction("Privacy", "Home");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }

    [HttpGet]
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Signup(Usuario user)
    {
        if (ModelState.IsValid)
        {
            user.FechaRegistro = DateTime.Now;
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        return RedirectToAction("Error", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
