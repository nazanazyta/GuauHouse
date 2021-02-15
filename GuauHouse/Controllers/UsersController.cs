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

        [AuthorizeValidation]
        public IActionResult Perfil()
        {
            return View(this.repo.GetPerrosUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [AuthorizeValidation]
        public IActionResult DatosUser()
        {
            return View(this.repo.GetUserByUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        [HttpPost]
        public async Task<IActionResult> DatosUser(IFormFile fichero, User user)
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                user.Imagen = fichero.FileName;
            }
            this.repo.EditUser(user);
            ViewData["mensaje"] = "Cambios guardados";
            //return RedirectToAction("Details", this.repo.GetPeliculaId(pelicula.IdPelicula));
            return View(this.repo.GetUserByUserName(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        //[AuthorizeValidation]
        //[Authorize(Policy = "SoloUsuarios")]
        public IActionResult Reserva()
        {
            return View();
        }
    }
}