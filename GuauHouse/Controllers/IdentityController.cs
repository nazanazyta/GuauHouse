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
                List<Claim> lista = new List<Claim>();
                lista.Add(new Claim(ClaimTypes.NameIdentifier, username));
                lista.Add(new Claim(ClaimTypes.Name, user.Nombre));
                lista.Add(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                lista.Add(new Claim(ClaimTypes.Sid, user.IdUsuario.ToString()));
                //lista.Add(new Claim(ClaimTypes.Email, user.Email));
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (lista, CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                //identity.AddClaim(new Claim(ClaimTypes.Name, user.Nombre));
                //identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                //identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddSeconds(30)
                    });
                if (principal.IsInRole("1"))
                {
                    return RedirectToAction("IndexAdmin", "Users");
                }
                else if (principal.IsInRole("2"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("IndexEmpleado", "Users");
                }
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
                ViewData["color"] = "aquamarine";
                return View();
            }
            else
            {
                ViewData["mensaje"] = "Ese usuario ya existe";
                ViewData["color"] = "lightcoral";
                return View();
            }
        }
    }
}
