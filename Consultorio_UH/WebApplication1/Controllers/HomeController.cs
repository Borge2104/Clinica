using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using Consultorio_UH.Security;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pass_Olvidado()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pass_Olvidado(Establecer_password Datos)
        {
            Correo Enviar = new Correo();
            
                if (Datos.Verificar_correo() == true)
                {
                    
                        
                        Enviar.para = Datos.Correo;

                        Enviar.Restablecer_Password();
                        ModelState.Clear();
                    ModelState.AddModelError("", "Se ha enviado el enlace para restablecer tu contraseña a tu correo");
                    return View();
                    
                }
                else
                {
                    ModelState.AddModelError("", "Correo inválido");
                }
            
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
                    ModelState.AddModelError("", "Correo inválido");
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
                    ModelState.AddModelError("", "Correo inválido");
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
            Sesion_persistente.Usuario = string.Empty;
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
                    Sesion_persistente.Nombre_logueado = Usuario.Usuario_Logueado();
                    Sesion_persistente.Usuario = Usuario.Correo;
                    Sesion_persistente.Rol_id = Usuario.Rol_id;
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

       [HttpPost]
        public ActionResult applogin(string email,string pass)
        {
            var jresult = new List<object>();
            Login l = new Login();
            l.Correo = email;
            l.Password = pass;
            if (l.verificar_usuario() == true)
            {
                string nombre_completo =l.Usuario_Logueado();
                jresult.Add(new { estado = true, nombre = nombre_completo,rol = l.Rol, rol_id = l.Rol_id });
            }
            else
            {
                jresult.Add(new { estado = false, error = "Email/Contraseña son incorrectos" });

            }
            return Json(jresult, JsonRequestBehavior.AllowGet);
        }
    }
}