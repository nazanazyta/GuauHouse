using GuauHouse.Filters;
using GuauHouse.Models;
using GuauHouse.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GuauHouse.Helpers;
using static GuauHouse.Helpers.Enumerations;

namespace GuauHouse.Controllers
{
    public class UsersController : Controller
    {
        IRepositoryGuauHouse repo;
        UploadService upload;

        public UsersController(IRepositoryGuauHouse repo, UploadService upload)
        {
            this.repo = repo;
            this.upload = upload;
        }

        [AuthorizeUser]
        public IActionResult Perfil()
        {
            return View(this.repo.GetPerrosIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        public IActionResult DatosUser()
        {
            return View(this.repo.GetUserById(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        [HttpPost]
        public IActionResult DatosUser(User user)
        {
            User usuario = this.repo.EditUser(user);
            //signout??
            return View(usuario);
        }

        public IActionResult ListaPerros()
        {
            return View(this.repo.GetPerrosIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        public IActionResult InsertarPerro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertarPerro(Perro perro, IFormFile fichero)
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                perro.Foto = fichero.FileName;
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            perro.IdUsu = int.Parse(userId);
            Perro p = this.repo.InsertarPerro(perro);
            return RedirectToAction("Perfil", "Users");
        }

        public IActionResult DatosPerro(int idperro)
        {
            return View(this.repo.GetPerroId(idperro));
        }

        [HttpPost]
        public async Task<IActionResult> DatosPerro(Perro perro, IFormFile fichero)
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                perro.Foto = fichero.FileName;
            }
            Perro p = this.repo.EditarPerro(perro);
            return View(p);
        }

        public IActionResult ListaReservas()
        {
            return View();
        }

        public IActionResult NuevaReserva()
        {
            return View();
        }

        [AuthorizeAdmin]
        public IActionResult IndexAdmin()
        {
            return View();
        }

        [AuthorizeEmpleado]
        public IActionResult IndexEmpleado()
        {
            return View();
        }
    }
}