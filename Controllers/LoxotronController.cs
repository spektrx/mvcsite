using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Loxotron.Controllers;

public class LoxotronController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index(string name)
    {
        ViewData["Message"] = "Hello " + name;
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Loxotron(int first, int second)
    {
        int result = first * second;
        return $"{result}";
    }
    //http://localhost:5272/helloworld/welcome?first=18&second=34
}