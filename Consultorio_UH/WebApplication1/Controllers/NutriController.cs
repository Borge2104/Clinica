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
    public class NutriController : Controller
    {
        [CustomAutorizarAtributos(Roles = "5")]
        public ActionResult Index()
        {
           
            return View();
        }

        [CustomAutorizarAtributos(Roles = "5")]
        public ActionResult MostrarCitas()
        {
            Doctor d = new Doctor();
            d.doctor_id = Convert.ToInt32(Sesion_persistente.Rol_id);
            d.fecha = DateTime.Now;
            d.mostrar();
            return View(d);
        }


        public ActionResult Citas(DateTime fecha, string hora)
        {
            Preconsulta p = new Preconsulta();
            p.fecha = fecha;
            p.hora = hora;
            p.mostrar();
            return View(p);

        }
        public ActionResult Ingreso(/*int preconsulta_id*/)
        {
            /* Doctor d = new Doctor();
             d.id_preconsulta = preconsulta_id;
             Preconsulta s = new Preconsulta();
             d.ds = s.buscar(preconsulta_id);
             if (d.ds.Rows[0][6].ToString() != "-1")
             {
                 d.id = Convert.ToInt32(d.ds.Rows[0][5].ToString());
             }
             return View(d);*/

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "5")]
        public ActionResult Ingreso(Preconsulta p)
        {
            if (ModelState.IsValid)
            {
                p.fecha = DateTime.Now;
                p.asistente_id = Convert.ToInt32(Sesion_persistente.Rol_id);
                p.ingreso();
                return RedirectToAction("MostrarCitas", "Doctor");
            }
            return View();
        }
    }
}