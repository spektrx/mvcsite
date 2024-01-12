using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class BlackJackController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index(string name)
    {
        ViewData["Message"] = "Hello " + name;
        return View();
    }
}