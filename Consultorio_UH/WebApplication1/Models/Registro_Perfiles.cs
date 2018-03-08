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
    public class Registro_Perfiles
    {
        public string rol_id { get; set; }
        [Required(ErrorMessage = "*Cedula")]
        [Range(100000000, 999999999, ErrorMessage = "*9 caracteres numericos requeridos")]
        public int identificacion { get; set; }
        [Required(ErrorMessage = "*Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "*Primer Apellido")]
        public string primer_apellido { get; set; }
        [Required(ErrorMessage = "*Segundo Apellido")]
        public string segundo_apellido { get; set; }
        [Required(ErrorMessage = "*Correo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "*Fecha Nacimiento")]
        public DateTime fecha_nac { get; set; }
        public char sexo { get; set; }
        public string estado_civil { get; set; }
        [Required(ErrorMessage = "*Telefono")]
        [Range(10000000, 99999999, ErrorMessage = "*8 caracteres numericos requeridos")]
        public int telefono { get; set; }
        [Required(ErrorMessage = "*Provincia")]
        public string provincia { get; set; }
        [Required(ErrorMessage = "*Canton")]
        public string canton { get; set; }
        [Required(ErrorMessage = "*Distrito")]
        public string distrito { get; set; }
        [Required(ErrorMessage = "*Direccion")]
        public string direccion_detallada { get; set; }
        public string tipo_sangre { get; set; }

        public string Cedula_accion { get; set; }

        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");
        public DataSet ds;
        public int Rol_validar()
        {
            int rol;
            switch (rol_id)
            {
                case "Paciente":
                    rol = 1;
                    return rol;
                    break;
                case "Administrador":
                    rol = 2;                    
                    return rol;
                    break;
                case "Asistente":
                    rol = 3;
                    return rol;
                    break;
                case "Doctor":
                    rol = 4;
                    return rol;
                    break;
                case "Nutricionista":
                    rol = 5;
                    return rol;
                    break;
                default:
                    rol = 1;
                    return rol;
                    break;
            }
            
        }
        public void Insertar_Usuario()
        {

            string rol = Rol_validar().ToString();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Insert into usuario(email, tipo) values('" + Correo + "'," + Rol_validar().ToString() + ");", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex) { string error = ex.Message; }
            
            conn.Close();


        }
        public void Actualizar_Usuario()
        {


            conn.Open();

            try
            {
                
                SqlCommand cmd = new SqlCommand("update usuario set tipo = "+Rol_validar().ToString()+" where email = '"+Correo+"';", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex) { }



        }
        public void Insertar_Perfil()
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

                SqlCommand cmd3 = new SqlCommand("Insert into perfil(usuario_id, identificacion, nombre, primer_apellido, segundo_apellido, fecha_nacimiento, sexo, estado_civil, telefono, provincia, canton,distrito, direccion_detallada, tipo_sangre)values(" + id + ",'" + identificacion.ToString() + "','" + nombre + "', '" + primer_apellido + "', '" + segundo_apellido + "', '" + fecha_nac.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "', '" + sexo + "', '" + estado_civil + "', '" + telefono.ToString() + "', '" + provincia + "', '" + canton + "','" + distrito + "','" + direccion_detallada + "', '" + tipo_sangre + "');", conn); ;
                cmd3.ExecuteNonQuery();
                
                conn.Close();
            }
            catch (SqlException ex)
            {

            }
            conn.Close();
        }
        public void Actualizar_Perfil()
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

                SqlCommand cmd3 = new SqlCommand("update perfil set nombre='"+nombre+"',primer_apellido='"+primer_apellido+"',segundo_apellido='"+segundo_apellido+"',sexo='"+sexo+"',estado_civil='"+estado_civil+"',telefono='"+telefono+"',provincia='"+provincia+"',canton='"+canton+"',distrito='"+distrito+"',direccion_detallada='"+direccion_detallada+"' where usuario_id="+id+";", conn); ;
                cmd3.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException ex)
            {

            }
            
        }

        public void Mostrar_Usuarios()
        {
            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                  "select * from usuarios_registrados", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            ds.Tables[0].Rows[0][1].ToString();
            conn.Close();
        }

        public void Buscar_id()
        {
            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                  "select * from usuarios_registrados where Cedula like'%"+identificacion+"%';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");   
            conn.Close();
        }
        public void Buscar_Nombre()
        {
            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                  "select * from usuarios_registrados where Nombre like'%" + nombre + "%';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            conn.Close();
        }
        public void Buscar_Correo()
        {
            ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                  "select * from usuarios_registrados where Correo like'%" + Correo + "%';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            conn.Close();
        }
        public void Eliminar_Usuario(string email)
        {
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("delete from usuario where email='"+email+"';", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex) { }
        }
    }
}

