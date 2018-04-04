using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using System.Globalization;
using Consultorio_UH.Security;

namespace Consultorio_UH.Controllers
{
    public class AsistenteController : Controller
    {
        [CustomAutorizarAtributos(Roles = "3")]
        public ActionResult Index()
        {
           
            return View();
        }

        [CustomAutorizarAtributos(Roles = "3")]
        public ActionResult MostrarCitas()
        {
            Preconsulta p = new Preconsulta();
            p.fecha = DateTime.Now;        
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "3")]
        public ActionResult MostrarCitas(Preconsulta p)
        {
            return RedirectToAction("Citas", "Asistente", new { fecha = p.fecha, hora = p.hora });
        }

        public ActionResult Citas(DateTime fecha, string hora)
        {
            Preconsulta p = new Preconsulta();
            p.fecha = fecha;
            p.hora = hora;
            p.mostrar();
            return View(p);

        }


    }
}