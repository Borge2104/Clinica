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

        [Required(ErrorMessage = "*Diagnostico")]
        public string diagnostico { get; set; }




        public DataTable ds = new DataTable();
        public DataTable medicamentos = new DataTable();
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
                SqlCommand cmd = new SqlCommand("Select motivo from diagnostico where id = " + id + ";", conn);
                cmd.Connection = conn;
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dstemp);
                conn.Close();
                diagnostico = dstemp.Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

        public void ingreso()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string sql = "";
                sql = "Insert into diagnostico Values " +
                "(@preconsulta_id,@fecha,@motivo)" + " SELECT @id = SCOPE_IDENTITY() FROM diagnostico";
                cmd.CommandText = sql;
                cmd.Parameters.Add("@preconsulta_id", SqlDbType.Int);
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                cmd.Parameters.Add("@motivo", SqlDbType.NVarChar);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@preconsulta_id"].Value = id_preconsulta;
                cmd.Parameters["@fecha"].Value = fecha;
                cmd.Parameters["@motivo"].Value = diagnostico;
                cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["@id"].Value;
                conn.Close();
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

    }
}