using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; 
using System.Data.SqlClient; 
using System.Web.Mvc; 


namespace Consultorio_UH.Models
{
    public class Servicios_Doctores
    {
        public int Doctor { get; set; }
        public int servicio { get; set; }
        public DateTime fecha { get; set; }
        private DataTable dsDoctores = new DataTable();
        private DataTable dsServicios = new DataTable();
        public List<SelectListItem> DNlist;// Lista de Doctores Medicina General
        public List<SelectListItem> DMGlist;//Lista de Doctores Nutrición
        public List<SelectListItem> Slist;
        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");


        public void Doctores()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ListaDoctores;", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsDoctores);
            List<SelectListItem> MDGlista = new List<SelectListItem>();
            List<SelectListItem> Nlista = new List<SelectListItem>();
            for (int i = 0; i < dsDoctores.Rows.Count; i++)
            {
                if (dsDoctores.Rows[i][2].ToString() == "1"){
                    SelectListItem a = new SelectListItem { Value = dsDoctores.Rows[i][1].ToString(), Text = dsDoctores.Rows[i][0].ToString() };
                    MDGlista.Add(a);
                }
                else
                {
                    SelectListItem a = new SelectListItem { Value = dsDoctores.Rows[i][1].ToString(), Text = dsDoctores.Rows[i][0].ToString() };
                    Nlista.Add(a);
                }
            }
            DMGlist = MDGlista;
            DNlist = Nlista;

            conn.Close();
        }

        public void Servicios()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select name,id from servicio;", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsServicios);
            List<SelectListItem> lista = new List<SelectListItem>();
            for (int i = 0; i < dsServicios.Rows.Count; i++)
            {
                SelectListItem a = new SelectListItem { Value = dsServicios.Rows[i][1].ToString(), Text = dsServicios.Rows[i][0].ToString() };
                lista.Add(a);
            }
            Slist = lista;
            conn.Close();
        }
    }
}