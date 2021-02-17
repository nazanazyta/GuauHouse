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
            return View(this.repo.GetPerrosByIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        public IActionResult DatosUser()
        {
            return View(this.repo.GetUserById(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        [HttpPost]
        public async Task<IActionResult> DatosUser(User user, IFormFile fichero)
            //String passwordantigua, String passwordnueva1, String passwordnueva2, 
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                user.Imagen = fichero.FileName;
            }
            User usuario = this.repo.EditUser(user);
            return View(usuario);
            //signout??
            //if (passwordnueva1 != passwordnueva2)
            //{
            //    ViewData["error1"] = "Las contraseñas no coindiden";
            //    if (fichero != null)
            //    {
            //        await this.upload.UploadFileAsync(fichero, Folders.Images);
            //        user.Imagen = fichero.FileName;
            //    }
            //    User usuario = this.repo.EditUser(user);
            //    return View(usuario);
            //}
            //else
            //{
            //    if (fichero != null)
            //    {
            //        await this.upload.UploadFileAsync(fichero, Folders.Images);
            //        user.Imagen = fichero.FileName;
            //    }
            //    User usuario = this.repo.EditUser(user, passwordantigua, passwordnueva1);
            //    if (usuario == null)
            //    {
            //        ViewData["error2"] = "Contraseña incorrecta";
            //        return View(this.repo.GetUserById(user.IdUsuario));
            //    }
            //    else
            //    {
            //        return View(usuario);
            //    }
            //}
        }

        [AuthorizeUser]
        public IActionResult ListaPerros()
        {
            return View(this.repo.GetPerrosByIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        public IActionResult InsertarPerro()
        {
            return View();
        }

        [AuthorizeUser]
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

        [AuthorizeUser]
        public IActionResult DatosPerro(int idperro)
        {
            return View(this.repo.GetPerroId(idperro));
        }

        [AuthorizeUser]
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

        [AuthorizeUser]
        public IActionResult EliminarPerro(int idperro)
        {
            this.repo.BorrarPerro(idperro);
            return RedirectToAction("ListaPerros", "Users");
        }

        [AuthorizeUser]
        public IActionResult InsertarReserva()
        {
            return View(this.repo.GetPerrosByIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [AuthorizeUser]
        [HttpPost]
        public IActionResult InsertarReserva(Reserva reserva)
        {
            this.repo.InsertarReserva(reserva);
            return RedirectToAction("ListaReservas", "Users");
        }

        [AuthorizeUser]
        public IActionResult ListaReservas()
        {
            List<Perro> perros = this.repo.GetPerrosByIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            ViewData["perros"] = perros;
            return View(this.repo.GetReservasUsuarioByIdUsuario(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
            //return View();
        }

        [AuthorizeUser]
        public IActionResult DatosReserva(int idreserva)
        {
            ViewData["perros"] = this.repo.GetPerrosByIdUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(this.repo.GetReservaUsuarioById(idreserva));
        }

        [AuthorizeUser]
        [HttpPost]
        public IActionResult DatosReserva(Reserva reserva)
        {
            this.repo.EditarReserva(reserva);
            return RedirectToAction("ListaReservas", "Users");
        }

        [AuthorizeUser]
        public IActionResult EliminarReserva(int idreserva)
        {
            this.repo.EliminarReserva(idreserva);
            return RedirectToAction("ListaReservas", "Users");
        }

        [AuthorizeAdmin]
        public IActionResult IndexAdmin()
        {
            return View(this.repo.GetEmpleados());
        }

        [AuthorizeAdmin]
        public IActionResult InsertarEmpleado()
        {
            return View();
        }

        [AuthorizeAdmin]
        [HttpPost]
        public async Task<IActionResult> InsertarEmpleado(User user, IFormFile fichero)
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                user.Imagen = fichero.FileName;
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            user.IdUsuario = int.Parse(userId);
            this.repo.InsertarEmpleado(user);
            return RedirectToAction("IndexAdmin", "Users");
        }

        [AuthorizeAdmin]
        public IActionResult DatosEmpleado(int idusuario)
        {
            return View(this.repo.GetUserById(idusuario));
        }

        [AuthorizeAdmin]
        [HttpPost]
        public async Task<IActionResult> DatosEmpleado(User user, IFormFile fichero) 
        {
            if (fichero != null)
            {
                await this.upload.UploadFileAsync(fichero, Folders.Images);
                user.Imagen = fichero.FileName;
            }
            User usuario = this.repo.EditUser(user);
            return View(usuario);
        }

        [AuthorizeAdmin]
        public IActionResult EliminarEmpleado(int idusuario)
        {
            this.repo.EliminarEmpleado(idusuario);
            return RedirectToAction("IndexAdmin", "Users");
        }

        [AuthorizeEmpleado]
        public IActionResult IndexEmpleado()
        {
            return View(this.repo.GetReservasUsuarioByDay());
        }
    }
}