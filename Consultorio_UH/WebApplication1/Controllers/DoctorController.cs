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
    public class DoctorController : Controller
    {
        static List<Medicamento> Lista_Medicamentos = new List<Medicamento>();
        [CustomAutorizarAtributos(Roles = "4")]
        public ActionResult Index()
        {
            
            return View();
        }

        [CustomAutorizarAtributos(Roles = "4")]
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
        public ActionResult Ingreso(int preconsulta_id)
        {
            Doctor d = new Doctor();
            d.id_preconsulta = preconsulta_id;
            Preconsulta s = new Preconsulta();
            d.ds = s.buscar(preconsulta_id);
            string a = d.ds.Rows[0][6].ToString();
            d.id = Convert.ToInt32(d.ds.Rows[0][6].ToString());
            if (a != "-1")
            {
                d.buscar();
                Medicamento m = new Medicamento();
                d.medicamentos = m.buscar(d.id);
            }
            return View(d);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "4")]
        public ActionResult Ingreso(Doctor p)
        {
            if (p.id == -1)
            {
                p.fecha = DateTime.Now;
                p.ingreso();
            }
            return RedirectToAction("Medicamento", "Doctor",new { diagnostico_id = p.id, preconsulta_id = p.id_preconsulta });
        }

        public ActionResult Medicamento(int diagnostico_id,int preconsulta_id)
        {
            Medicamento m = new Medicamento();
            m.diagnostico_id= diagnostico_id;
            m.id_preconsulta = preconsulta_id;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAutorizarAtributos(Roles = "4")]
        public ActionResult Medicamento(Medicamento m)
        {
            m.ingreso();
            return RedirectToAction("Ingreso", "Doctor", new { preconsulta_id = m.id_preconsulta });
        }
        
    }
}