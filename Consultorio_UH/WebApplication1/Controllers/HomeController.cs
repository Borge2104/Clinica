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
                    switch (Usuario.Rol)
                    {
                        case "1":

                            return RedirectToAction("Index", "Paciente");
                            break;
                        case "2":
                            return RedirectToAction("Index", "Admi");
                            break;
                        case "3":
                            return RedirectToAction("Index", "Asistente");
                            break;
                        case "4":
                            return RedirectToAction("Index", "Doctor");
                            break;
                        case "5":
                            return RedirectToAction("Index", "Nutri");
                            break;
                        default:
                            return RedirectToAction("Index", "Home");
                            break;
                    }
                    


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