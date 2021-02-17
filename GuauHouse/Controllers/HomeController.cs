using GuauHouse.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Controllers
{
    public class HomeController : Controller
    {
        MailService MailService;

        public HomeController(MailService mailservice)
        {
            this.MailService = mailservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Tarifas()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(String nombre, String email, String asunto, String mensaje)
        {
            this.MailService.SendEmail(email, asunto, mensaje);
            ViewData["mensaje"] = "Correo enviado " + nombre + ". Te responderemos lo antes posible. Gracias";
            return View();
        }
    }
}
