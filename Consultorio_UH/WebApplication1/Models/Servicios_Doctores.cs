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
        public DataSet dsServicios;
        public int Doctor;
        public DataTable dsDoctores  = new DataTable();
        public List<SelectListItem> Dlist  { get; set; }
        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void Doctores()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ListaDoctores;", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsDoctores);
            List<SelectListItem> lista = new List<SelectListItem>();
            for (int i = 0; i < dsDoctores.Rows.Count; i++)
            {
               SelectListItem a = new SelectListItem { Value = dsDoctores.Rows[i][1].ToString(), Text = dsDoctores.Rows[i][0].ToString()};
                lista.Add(a);
            }
            Dlist = lista;
            conn.Close();
            
        }
        public void Servicios()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id,name from servicio;", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dsServicios, "tabla");

        }
    }
}