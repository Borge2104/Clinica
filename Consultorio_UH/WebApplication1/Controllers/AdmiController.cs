using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using System.Globalization;
namespace WebApplication1.Controllers
{
    public class AdmiController : Controller
    {
        // GET: Admi
        public ActionResult Index()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            return View();
        }
        public ActionResult Registro_Perfiles()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            return View();
        }

        public ActionResult Usuarios_Registrados()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro_Perfiles UR = new Registro_Perfiles();
            UR.Mostrar_Usuarios();
            return View(UR);
        }

       
        public ActionResult Eliminar(string id)
        {
            string ced = id;
            return RedirectToAction("Usuarios_Registrados", "Admi");
        }
        public ActionResult Actualizar(string id)
        {

            return RedirectToAction("Usuarios_Registrados", "Admi");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro_Perfiles(Registro_Perfiles Registro)
        {
            
           
            if (ModelState.IsValid)
            {
                ViewBag.Message = Usuario_logueado.Nombre_apellido;
                Registro.Insertar_Usuario();
                Registro.Insertar_Perfil();
              
                
               
            }
            if ( 
                Registro.nombre != null &&
                Registro.primer_apellido != null &&
                Registro.segundo_apellido != null &&
                Registro.Correo != null &&
                Registro.fecha_nac != null &&
                Registro.provincia != null &&
                Registro.canton != null &&
                Registro.distrito != null &&
                Registro.direccion_detallada != null)
            {
                ModelState.Clear();
                 ModelState.AddModelError("", "Registrado Satisfactoriamente");
                
            }

            
            return View();



        }
       


    }
}