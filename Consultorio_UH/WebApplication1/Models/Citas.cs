using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Consultorio_UH.Models
{
    public class Citas
    {
        public int id { get; set; }
        public int paciente_id { get; set; }
        public int doctor_id { get; set; }
        public int servicio_id { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public string hora { get; set; }
        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void insertar()
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            string sql = "";
            sql = "Insert into cita Values " +
            "(@paciente,@doctor,@fecha,@estado,@hora)";
            cmd.CommandText = sql;
            // cmd.Parameters.Add("@id_pr", SqlDbType.Int);
            cmd.Parameters.Add("@paciente", SqlDbType.Int);
            cmd.Parameters.Add("@doctor", SqlDbType.Int);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            cmd.Parameters.Add("@estado", SqlDbType.NVarChar);
            cmd.Parameters.Add("@hora", SqlDbType.NVarChar);
            cmd.Parameters["@paciente"].Value = paciente_id;
            cmd.Parameters["@doctor"].Value = doctor_id;
            cmd.Parameters["@fecha"].Value = fecha;
            cmd.Parameters["@estado"].Value = 1;
            cmd.Parameters["@hora"].Value = hora;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void mostrar()
        {
            try {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Agenda("+doctor_id+",'" + fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "');", conn);
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