using AcademyF.TestWeek7.Core.BusinessLayer;
using AcademyF.TestWeek7.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcademyF.TestWeek7.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBusinessLayer BL;
        public UserController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new UserViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserViewModel userVM)
        {
            if (userVM == null)
            {
                return View();
            }
            var utente = BL.GetAccount(userVM.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == userVM.Password)
                {
                    //l'utente è "autenticato"
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Username),
                        new Claim(ClaimTypes.Role, utente.Role.ToString())
                    };
                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = userVM.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                    };
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), properties);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(userVM.Password), "Password errata");
                    return View(userVM);
                }
            }
            else
            {
                return View(userVM);
            }
            return View();
        }

        public IActionResult Forbidden() => View();

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
