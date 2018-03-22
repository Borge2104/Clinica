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
    public class PacienteController : Controller
    {
        [CustomAutorizarAtributos(Roles = "1")]

        public ActionResult Index()
        {

            return View();
        }
        [CustomAutorizarAtributos(Roles = "1")]
        [HttpPost]
        public ActionResult Citas()
        {

            return View();
        }
        [CustomAutorizarAtributos(Roles = "1")]
        [HttpGet]
        public ViewResult Citas(int id_doctor,int id_servicio, DateTime fecha)
        {
            Citas c = new Citas();
            c.servicio_id = id_servicio;
            c.doctor_id = id_doctor;
            c.fecha = fecha;
            c.mostrar();
            return View(c);
        }
        [CustomAutorizarAtributos(Roles = "1")]
        public ActionResult SolicitudCitas()
        {
            Servicios_Doctores sd = new Servicios_Doctores();
            sd.Doctores();
            sd.Servicios();
            return View(sd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "1")]
        public ActionResult SolicitudCitas(Servicios_Doctores sd)
        {
            return RedirectToAction("Citas", "Paciente", new { id_doctor = sd.Doctor, id_servicio = sd.servicio, fecha = sd.fecha });
        }

        [CustomAutorizarAtributos(Roles = "1")]
        [HttpGet]
        public ActionResult CitasIngreso(int id_paciente,int doctor_id, DateTime fecha,string hora)
        {
            Citas c = new Citas();
            c.paciente_id = id_paciente;
            c.doctor_id = doctor_id;
            c.fecha = fecha;
            c.hora = hora;
            c.insertar();
            return View();
        }
    }
}