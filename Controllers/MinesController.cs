using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class MinesController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index(string name)
    {
        return View();
    }
}