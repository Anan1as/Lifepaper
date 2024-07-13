using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lifepaper.Models;
using Lifepaper.Data;

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

        // -----------------------------------------------------------------Pruebas

        var user = _context.Usuarios.FirstOrDefault(f=>f.Nombre == username && f.Contraseña == password);

        if(user!=null){
            return RedirectToAction("Privacy", "Home");
        }else{
            return RedirectToAction("Index", "Users");
        }

        // ----------------------------------------------------------------Fin de Pruebas
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
