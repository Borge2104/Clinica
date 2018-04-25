using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Consultorio_UH.Models
{
    
    public class Login
    {
       
        [Required(ErrorMessage = "*Correo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "*Contraseña")]
        public string Password { get; set; }

        public string Rol { get; set; }
    
        public string Rol_id { get; set; }
        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");
        private DataSet ds;
        public Boolean verificar_usuario()
        {
            string id;
            string pass;

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id,tipo from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();
                Rol = ds.Tables["tabla"].Rows[0]["tipo"].ToString();

                SqlCommand cmd2 = new SqlCommand("select pass from contraseña where usuario_id=" + id + ";", conn);
                SqlDataAdapter adap2 = new SqlDataAdapter(cmd2);
                ds.Clear();
                adap2.Fill(ds, "tabla");
                pass = ds.Tables["tabla"].Rows[0]["pass"].ToString();

                conn.Close();
            }
            catch
            {
                return false;
            }
            if (id.Equals(""))
            {
                return false;
            }
            else
            {
                if (pass.Equals(Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public Login verificar_usuario_modelo(string Usuario)
        {
            string id;
            string pass;
            Login Retorno=new Models.Login();

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id,tipo from usuario where email='" + Usuario + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();
                Rol = ds.Tables["tabla"].Rows[0]["tipo"].ToString();
                SqlCommand cmd2 = new SqlCommand("select pass from contraseña where usuario_id=" + id + ";", conn);
                SqlDataAdapter adap2 = new SqlDataAdapter(cmd2);
                ds.Clear();
                adap2.Fill(ds, "tabla");
                pass = ds.Tables["tabla"].Rows[0]["pass"].ToString();

                conn.Close();
                Retorno.Correo = Usuario;
                Retorno.Password = pass;
                Retorno.Rol = Rol;
                
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
            return Retorno;
        }

        public string Usuario_Logueado()
        {

            string Nombre_Apellido;
            string id;

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();

                SqlCommand cmd2 = new SqlCommand("select nombre,primer_apellido from perfil where usuario_id=" + id + ";", conn);
                SqlDataAdapter adap2 = new SqlDataAdapter(cmd2);
                ds.Clear();
                adap2.Fill(ds, "tabla");
                Nombre_Apellido = ds.Tables["tabla"].Rows[0]["nombre"].ToString()+" "+ ds.Tables["tabla"].Rows[0]["primer_apellido"].ToString();
                if (Rol != "2")
                {
                    cmd = new SqlCommand("select id from " + Obtener_Tabla(Rol) + " where usuario_id ='" + id + "';", conn);
                    adap = new SqlDataAdapter(cmd);
                    ds.Clear();
                    adap.Fill(ds, "tabla");
                    Rol_id = ds.Tables["tabla"].Rows[0][0].ToString();
                }
                else
                    Rol_id = "0";
                conn.Close();

                return Nombre_Apellido;
            }
            catch
            {
                Nombre_Apellido = "";
                return Nombre_Apellido;
            }
        }

        private string Obtener_Tabla(string rol)
        {
            string tabla = "";
            switch (rol)
                {
                case "1":
                    tabla = "paciente";
                    break;
                case "2":
                    tabla = "administrador";
                    break;
                case "3":
                    tabla = "asistente";
                    break;
                case "4":
                    tabla = "doctor";
                    break;
                case "5":
                    tabla = "doctor";
                    break;
            }
            return tabla;
        }


       

    }


}