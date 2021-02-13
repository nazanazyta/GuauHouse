using GuauHouse.Models;
using GuauHouse.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuauHouse.Controllers
{
    public class IdentityController : Controller
    {
        IRepositoryGuauHouse repo;

        public IdentityController(IRepositoryGuauHouse repo)
        {
            this.repo = repo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(String username, String password)
        {
            User user = this.repo.ValidateUser(username, password);
            if (user == null)
            {
                ViewData["mensaje"] = "Usuario/Password incorrectos";
                return View();
            }
            else
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Nombre));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddSeconds(15)
                    });
                return RedirectToAction("Perfil", "Users");
            }
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(User user)
        {
            if (this.repo.GetUserByUserName(user.UserName) == null)
            {
                User u = this.repo.InsertUser(user);
                ViewData["mensaje"] = "Usuario registrado correctamente";
                return View();
            }
            else
            {
                ViewData["mensaje"] = "Ese usuario ya existe";
                return View();
            }
        }
    }
}
