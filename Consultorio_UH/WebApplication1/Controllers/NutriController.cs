using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
using System.Globalization;
using Consultorio_UH.Security;
using System.Data;

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
        [HttpGet]
        public ActionResult Ingreso2(int preconsulta_id)
        {
             Nutricion_consulta n = new Nutricion_consulta();
             n.preconsulta_id = preconsulta_id;
             Preconsulta s = new Preconsulta();
             DataTable pr = s.buscar(preconsulta_id);
           n.paciente = pr.Rows[0][1].ToString();
            n.peso = Convert.ToDecimal(pr.Rows[0][3].ToString());
            n.Edad = pr.Rows[0][7].ToString();
            n.genero = pr.Rows[0][8].ToString();
            return View(n);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "5")]
        public ActionResult Ingreso2(Nutricion_consulta n)
        {
                n.fecha = DateTime.Now;
                n.ingreso();
                return RedirectToAction("MostrarCitas", "Nutri");
        }
    }
}