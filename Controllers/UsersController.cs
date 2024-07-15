using Microsoft.AspNetCore.Mvc;
using Lifepaper.Data;
using System.Linq;

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
        return View("Error!");
    }
}
