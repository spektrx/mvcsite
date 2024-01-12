using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcsite.Data;
using mvcsite.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace mvcsite.Controllers
{
    public class AccountController : Controller
    {

        ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string? returnUrl, IFormCollection form)
        {
            string name = form["name"];
            string password = form["password"];

            User? user = await db.Users.FirstOrDefaultAsync(user => user.Name == name && user.Password == password);

            if (user == null) { return Unauthorized("аккаунт не найден"); }

            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, name)};
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));


            return Redirect(returnUrl ?? "/");
        }

        [Authorize]
        public async Task<RedirectResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }


        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
