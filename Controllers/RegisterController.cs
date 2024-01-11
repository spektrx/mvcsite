using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using mvcsite.Data;
using mvcsite.Models;
using System.Security.Claims;

namespace mvcsite.Controllers
{
    public class RegisterController : Controller
    {

        ApplicationContext db;

        public RegisterController(ApplicationContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<RedirectResult> Register(IFormCollection form)
        {
            string name = form["name"];
            string password = form["password"];

            User user = new() {Name=name, Password=password };

            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();

            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, name) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

            return Redirect("/");
        }
    }
}
