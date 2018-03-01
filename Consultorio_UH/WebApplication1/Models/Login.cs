using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Consultorio_UH.Models
{
    public class Login
    {

        public string Correo { get; set; }
        public string Password { get; set; }

        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");
        private DataSet ds;
        public Boolean verificar_usuario()
        {
            string id;
            string pass;

            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();

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

        private static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }


}