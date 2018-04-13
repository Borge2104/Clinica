using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
namespace Consultorio_UH.Models
{
    public class Preconsulta
    {
        public int id { get; set; }
        public int cita_id { get; set; }
        public int asistente_id { get; set; }
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "*Motivo")]
        public string motivo{ get; set; }
        public string hora { get; set; }
        [Required(ErrorMessage = "*Peso")]
        [Range(0.1, 200.0, ErrorMessage = "*Proporcione una medida correcta 0.0 kg")]
        public decimal peso  { get; set; }
        [Required(ErrorMessage = "*Estatura")]
        [Range(0.1, 4.0, ErrorMessage = "*Proporcione una medida correcta 0.0 m")]
        public decimal estatura { get; set; }
        [Required(ErrorMessage = "*Presion")]
        public string presion { get; set; }

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
        public DataTable buscar(int id_preconsulta)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from PreconsultaDetallePaciente("+id_preconsulta+");", conn);
            cmd.Connection = conn;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            return ds;

        }

        public void ingreso()
        {
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            string sql = "";
            sql = "Insert into preconsulta Values " +
            "(@cita_id,@asistente_id,@fecha,@motivo)"+ " SELECT @id = SCOPE_IDENTITY() FROM preconsulta";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@cita_id", SqlDbType.Int);
            cmd.Parameters.Add("@asistente_id", SqlDbType.Int);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            cmd.Parameters.Add("@motivo", SqlDbType.NVarChar);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@cita_id"].Value = cita_id;
            cmd.Parameters["@asistente_id"].Value = asistente_id;
            cmd.Parameters["@fecha"].Value = fecha;
            cmd.Parameters["@motivo"].Value = motivo;
            cmd.ExecuteNonQuery();
            id = (int)cmd.Parameters["@id"].Value;
            conn.Close();
            cmd.Dispose();
            conn.Open();
            cmd.Connection = conn;
            sql = "Insert into datos_preconsulta Values " +
                "(@preconsulta_id,@peso,@estatura,@presion)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@preconsulta_id", SqlDbType.Int);
            cmd.Parameters.Add("@peso", SqlDbType.Decimal);
            cmd.Parameters.Add("@estatura", SqlDbType.Decimal);
            cmd.Parameters.Add("@presion", SqlDbType.NVarChar);
            cmd.Parameters["@preconsulta_id"].Value = id;
            cmd.Parameters["@peso"].Value = peso;
            cmd.Parameters["@estatura"].Value = estatura;
            cmd.Parameters["@presion"].Value = presion;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}