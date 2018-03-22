using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using System.Globalization;
using Consultorio_UH.Security;
using Consultorio_UH.Models;
namespace WebApplication1.Controllers
{
    public class AdmiController : Controller
    {
        [CustomAutorizarAtributos(Roles ="2")]
        public ActionResult Index()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            return View();
        }
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Registro_Perfiles()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            return View();
        }
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Usuarios_Registrados()
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro_Perfiles UR = new Registro_Perfiles();
            UR.Mostrar_Usuarios();
            return View(UR);
        }

        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Eliminar(string Correo)
        {
            Registro_Perfiles UR = new Registro_Perfiles();
            UR.Eliminar_Usuario(Correo);
            return RedirectToAction("Usuarios_Registrados", "Admi");
        }

        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Actualizar(string Perfil, string Cedula,string Nombre,string Apellido_P, string Apellido_M, string Correo, string Fecha_Nac, string Sexo,
                                       string Estado_civil, string Telefono, string Provincia, string Canton, string Distrito, string Direccion, string Tipo_sangre)
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro_Perfiles Registro = new Registro_Perfiles();
            Registro.rol_id = Perfil;
            Registro.identificacion = Int32.Parse(Cedula);
            Registro.nombre = Nombre;
            Registro.primer_apellido = Apellido_P;
            Registro.segundo_apellido = Apellido_M;
            Registro.Correo = Correo;
            Registro.fecha_nac =Convert.ToDateTime(Fecha_Nac);
            Registro.sexo = Convert.ToChar(Sexo);
            Registro.estado_civil = Estado_civil;
            Registro.telefono = Int32.Parse(Telefono);
            Registro.provincia = Provincia;
            Registro.canton = Canton;
            Registro.distrito = Distrito;
            Registro.direccion_detallada = Direccion;
            Registro.tipo_sangre = Tipo_sangre;
            return View(Registro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Actualizar(Registro_Perfiles Registro)
        {
            
                ViewBag.Message = Usuario_logueado.Nombre_apellido;
                Registro.Actualizar_Usuario();
                
                Registro.Actualizar_Perfil();
                Registro.Actualizar_Usuario();
                Registro.Insertar_Rol();


            return RedirectToAction("Usuarios_Registrados", "Admi");
        }
        [HttpPost]
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult Buscar_id(Registro_Perfiles Registro)
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro.Buscar_id();
            return View(Registro);
        }

        [HttpPost]
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult BuscarNombre(Registro_Perfiles Registro)
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro.Buscar_Nombre();
            return View(Registro);
        }
        [HttpPost]
        [CustomAutorizarAtributos(Roles = "2")]
        public ActionResult BuscarCorreo(Registro_Perfiles Registro)
        {
            ViewBag.Message = Usuario_logueado.Nombre_apellido;
            Registro.Buscar_Correo();
            return View(Registro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro_Perfiles(Registro_Perfiles Registro)
        {
            Correo Enviar = new Correo();
            
           
            if (ModelState.IsValid)
            {
                ViewBag.Message = Usuario_logueado.Nombre_apellido;
                Registro.Insertar_Usuario();
                Registro.Insertar_Perfil();
                Registro.Insertar_Rol();
                Enviar.para = Registro.Correo;
                Enviar.Establecer_Password();
                ModelState.Clear();
                ModelState.AddModelError("", "Registrado Satisfactoriamente");

            }
          

            
            return View();



        }
       


    }
}