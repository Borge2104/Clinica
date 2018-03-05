using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using System.Globalization; 

namespace Consultorio_UH.Controllers
{
    public class AsistenteController : Controller
    {
        // GET: Asistente
        public ActionResult Index()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            return View();
        }
    }
}