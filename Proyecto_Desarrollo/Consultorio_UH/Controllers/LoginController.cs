using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;

namespace Consultorio_UH.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //  Post: Login
     

        [HttpPost]
        public ActionResult Validar(Login Usuario)
        {
            if (Usuario.verificar_usuario() == true)
            {
                return RedirectToAction("Administrador");

            }
            else
            { return View(); }

        }

        

    }
}