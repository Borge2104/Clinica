using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Consultorio_UH.Models
{
    public class Establecer_password
    {

        [Required(ErrorMessage = "*Correo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "*Ingresa tu Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Confirma tu contraseña")]
        public string Password2 { get; set; }
        private DataSet ds;
        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public Boolean Verificar_correo()
        {
            string id=null;
            string pass;

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select email from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try { id = ds.Tables["tabla"].Rows[0]["email"].ToString(); }
            catch { }
            conn.Close();

            if (id==null)
            { return false; }
            else
            { return true; }
                

        }

        public void Insertar_password()
        {
            string id;
            

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();


                SqlCommand cmd2 = new SqlCommand("Insert into contraseña (pass,usuario_id) values('" + Password2 + "',"+id+");", conn);
                cmd2.ExecuteNonQuery();
                ds.Clear();


                conn.Close();
            }
            catch { }
        }
        public void Modificar_password()
        {
            string id;


            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();


                SqlCommand cmd2 = new SqlCommand("Update contraseña set pass="+Password2+"where id="+id+";", conn);
                cmd2.ExecuteNonQuery();
                ds.Clear();


                conn.Close();
            }
            catch { }
        }

    }
}