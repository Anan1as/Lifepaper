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

    public IActionResult SignIn(string username, string password)
    {
<<<<<<< HEAD
=======

        // -----------------------------------------------------------------Pruebas

>>>>>>> 527690bff76cda2fc656ea47e2d4ccbd60818019
        var user = _context.Usuarios.FirstOrDefault(f=>f.Nombre == username && f.Contraseña == password);
        if(user!=null){
            return RedirectToAction("Privacy", "Home");
        }else{
            return RedirectToAction("Error", "Home");
        }
    }

<<<<<<< HEAD
    [HttpGet]
=======
        // ----------------------------------------------------------------Fin de Pruebas
    }

>>>>>>> 527690bff76cda2fc656ea47e2d4ccbd60818019
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
            return RedirectToAction("Home");
        }
        return RedirectToAction("Error", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
