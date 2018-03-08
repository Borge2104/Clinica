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
        public ActionResult Modificar_password()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar_password(Establecer_password Datos)
        {
            Correo Enviar = new Correo();
            if (ModelState.IsValid)
            {
                if (Datos.Verificar_correo() == true)
                {
                    if (Datos.Password.Equals(Datos.Password2))
                    {
                        Datos.Modificar_password();
                        Enviar.para = Datos.Correo;
                        Enviar.pass = Datos.Password2;
                        Enviar.Notificacion();
                        ModelState.Clear();
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    { ModelState.AddModelError("", "Contraseñas no validas"); }
                }
                else
                {
                    ModelState.AddModelError("", "El correo ingresado,no es valido");
                }
            }
            return View();
        }
        public ActionResult Establecer_password()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Establecer_password(Establecer_password Datos)
        {
            Correo Enviar = new Correo();
            if (ModelState.IsValid)
            {
                if (Datos.Verificar_correo() == true)
                {
                    if (Datos.Password.Equals(Datos.Password2))
                    {
                        Datos.Insertar_password();
                        Enviar.para = Datos.Correo;
                        Enviar.pass = Datos.Password2;
                        Enviar.Notificacion();
                        ModelState.Clear();
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    { ModelState.AddModelError("", "Contraseñas no validas"); }
                }
                else
                {
                    ModelState.AddModelError("", "El correo ingresado,no es valido");
                }
            }
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