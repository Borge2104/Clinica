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
        public DataSet ds;
        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");


        public void insertar()
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            string sql = "";
            sql = "Insert into Citas Values " +
            "(@paciente,@doctor,@servicio,@fecha,@estado)";
            cmd.CommandText = sql;
            // cmd.Parameters.Add("@id_pr", SqlDbType.Int);
            cmd.Parameters.Add("@paciente", SqlDbType.Int);
            cmd.Parameters.Add("@doctor", SqlDbType.Int);
            cmd.Parameters.Add("@servicio", SqlDbType.Int);
            cmd.Parameters.Add("@fecha", SqlDbType.Int);
            cmd.Parameters.Add("@estado", SqlDbType.NVarChar);
            cmd.Parameters["@paciente"].Value = paciente_id;
            cmd.Parameters["@doctor"].Value = doctor_id;
            cmd.Parameters["@servicio"].Value = servicio_id;
            cmd.Parameters["@fecha"].Value = fecha;
            cmd.Parameters["@estado"].Value = 1;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}