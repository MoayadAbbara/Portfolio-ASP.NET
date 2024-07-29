using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MoayadPortfolio.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult Index()
        {
            return PartialView("Login");
        }
        public IActionResult Login(DTO.Request.UserLogin UserInfo)
        {
            var claims = BusinessLayer.Auth.Login(UserInfo.Email, UserInfo.Password);
            if (claims != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties();
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal, properties);

                return RedirectToAction("Index", "Home");
            }

            return PartialView("/Views/Auth/Login.cshtml");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
