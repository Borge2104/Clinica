using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace Consultorio_UH.Models
{
    public class Preconsulta
    {
        public int id { get; set; }
        public int cita_id { get; set; }
        public int doctor_id { get; set; }
        public int asistente_id { get; set; }
        public DateTime fecha { get; set; }
        public string motivo{ get; set; }
        public string hora { get; set; }
        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void mostrar()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from PreconsultaCitas('"+ hora + "','" + fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) +"');", conn);
                cmd.Connection = conn;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(ds);
                conn.Close();
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }
    }
}