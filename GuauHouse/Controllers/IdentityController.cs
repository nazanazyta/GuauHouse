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

        public IActionResult Login(String error)
        {
            ViewData["mensaje"] = error;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(String username, String password)
        {
            User user = this.repo.ValidateUser(username, password);
            if (user == null)
            {
                //ARREGLO!: Mandar a otra vista
                //ViewData["mensaje"] = "Usuario/Password incorrectos";
                //return RedirectToAction("Login", "Identity", new { error = "Usuario/Password incorrectos" });
                return RedirectToAction("ErrorLogin", "Identity");
            }
            else
            {
                List<Claim> lista = new List<Claim>();
                lista.Add(new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()));
                lista.Add(new Claim(ClaimTypes.Name, username));
                lista.Add(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (lista, CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.IdUsuario.ToString()));
                //identity.AddClaim(new Claim(ClaimTypes.Name, username));
                //identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddMinutes(2)
                    });
                if (principal.IsInRole("1"))
                {
                    return RedirectToAction("IndexAdmin", "Users");
                }
                else if (principal.IsInRole("2"))
                {
                    return RedirectToAction("Perfil", "Users");
                }
                else
                {
                    return RedirectToAction("IndexEmpleado", "Users");
                }
            }
        }

        public IActionResult ErrorLogin()
        {
            return View();
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
                //ViewData["mensaje"] = "Ese usuario ya existe";
                //ViewData["color"] = "lightcoral";
                return RedirectToAction("ErrorRegistro", "Identity");
            }
        }

        public IActionResult ErrorRegistro()
        {
            return View();
        }
    }
}
