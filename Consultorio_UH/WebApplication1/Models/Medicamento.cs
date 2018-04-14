using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace Consultorio_UH.Models
{
    public class Medicamento
    {
        public int diagnostico_id { get; set; }
        public int id_preconsulta { get; set; }
        [Required(ErrorMessage = "*Medicamento")]
        public string medicamento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        [Required(ErrorMessage = "*dosis")]
        public string dosis { get; set; }
        [Required(ErrorMessage = "*Detalle")]
        public string detalle { get; set; }

        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void ingreso()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string sql = "";
                sql = "Insert into tratamiento Values " +
                "(@diagnostico_id,@medicamento,@fechaInicio,@fechaFinal,@dosis,@Detalle);";
                cmd.CommandText = sql;
                cmd.Parameters.Add("@diagnostico_id", SqlDbType.Int);
                cmd.Parameters.Add("@medicamento", SqlDbType.NVarChar);
                cmd.Parameters.Add("@fechaInicio", SqlDbType.DateTime);
                cmd.Parameters.Add("@fechaFinal", SqlDbType.DateTime);
                cmd.Parameters.Add("@dosis", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Detalle", SqlDbType.NVarChar);
                cmd.Parameters["@diagnostico_id"].Value = diagnostico_id;
                cmd.Parameters["@medicamento"].Value = medicamento;
                cmd.Parameters["@fechaInicio"].Value = fecha_inicio;
                cmd.Parameters["@fechaFinal"].Value = fecha_final;
                cmd.Parameters["@dosis"].Value = dosis;
                cmd.Parameters["@Detalle"].Value = detalle;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
         
            {
                conn.Close();
                string a = e.Message;
            }
        }
        public DataTable buscar(int diagnostico_id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from tratamiento where diagnostico_id = "+ diagnostico_id + ";", conn);
            cmd.Connection = conn;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}