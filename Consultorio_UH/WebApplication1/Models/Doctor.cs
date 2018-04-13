using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Consultorio_UH.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public int cita_id { get; set; }
        public int id_preconsulta { get; set; }
        public int doctor_id { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }

        [Required(ErrorMessage = "*Diagnostico")]
        public string diagnostico { get; set; }

        [Required(ErrorMessage = "*Medicamento")]
        public string medicamento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        [Required(ErrorMessage = "*dosis")]
        public int dosis { get; set; }
        [Required(ErrorMessage = "*Detalle")]
        public string detalle { get; set; }




        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void mostrar()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from doctorCitas('" + fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "'," + doctor_id + ");", conn);
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
        public void buscar()
        {
            try
            {
                DataTable dstemp = new DataTable();
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Diagnostico where id = " + id + ";", conn);
                cmd.Connection = conn;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dstemp);
                conn.Close();
                motivo = dstemp.Rows[0][0].ToString();      
            }
            catch (Exception e)
            {
                string a = e.Message;
            }

        }
    }
}