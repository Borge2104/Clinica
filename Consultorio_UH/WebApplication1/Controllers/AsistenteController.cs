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
    }
}