using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        //[HttpGet]
        //public ActionResult nombre()
        //{

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login Usuario)
        {


            if (ModelState.IsValid)
            {
                if (Usuario.verificar_usuario() == true)
                {

                    Usuario_logueado.Nombre_apellido = Usuario.Usuario_Logueado();
                    return RedirectToAction("Index", "Admi");


                }

            }
            
                if (Usuario.Correo!=null && Usuario.Password !=null)
                {
                    ModelState.AddModelError("", "Email/Contraseña son incorrectos.");
                    
                }

            return View();  

                  

        }
       
    }
}