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
            return View(this.repo.GetPerrosUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [AuthorizeUser]
        public IActionResult DatosUser()
        {
            return View(this.repo.GetUserByUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [AuthorizeUser]
        [HttpPost]
        public IActionResult DatosUser(User user)
        {
            User usuario = this.repo.EditUser(user);
            return View(usuario);
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
            var userId = User.FindFirst(ClaimTypes.Sid).Value;
            perro.IdUsu = int.Parse(userId);
            Perro p = this.repo.InsertarPerro(perro);
            return RedirectToAction("Perfil", "Users");
        }

        public IActionResult DatosPerro(int idperro)
        {
            return View(this.repo.GetPerroId(idperro));
        }

        [HttpPost]
        public IActionResult DatosPerro(Perro perro)
        {
            Perro p = this.repo.EditarPerro(perro);
            return View(p);
        }

        //[AuthorizeUser]
        //[HttpPost]
        //public async Task<IActionResult> DatosUser(IFormFile fichero, User user)
        //{
        //    if (fichero != null)
        //    {
        //        await this.upload.UploadFileAsync(fichero, Folders.Images);
        //        user.Imagen = fichero.FileName;
        //    }
        //    User usuario = this.repo.EditUser(user.IdUsuario, user.Nombre);
        //    ViewData["mensaje"] = "Cambios guardados";
        //    String nombre = usuario.Nombre;
        //    //return RedirectToAction("Details", this.repo.GetPeliculaId(pelicula.IdPelicula));
        //    return View(this.repo.GetUserByUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        //}


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