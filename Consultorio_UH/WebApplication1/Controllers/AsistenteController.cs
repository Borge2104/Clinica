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

        [HttpGet]
        public ActionResult Citas_preconsulta()
        {

            return View();
        }
        /* [HttpPost]
         public ActionResult Citas_preconsulta()
         {

             return View();
         }
         */
        public ActionResult Preconsulta()
        {

            return View();
        }

    }
}