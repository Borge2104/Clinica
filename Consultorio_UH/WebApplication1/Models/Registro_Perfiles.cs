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
        public DataSet dse;
        public DataSet count;
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
        public void Insertar_Rol()
        {
            string comp;
            string id;
            string rol = Rol_validar().ToString();
            int contar = 0;
            ds = new DataSet();
            dse = new DataSet();
            count = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id from usuario where email='" + Correo + "';", conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds, "tabla");
            conn.Close();
            try
            {
                id = ds.Tables["tabla"].Rows[0]["id"].ToString();


                switch (rol)
                {
                    case "1":

                        conn.Open();
                        SqlCommand cmd_count = new SqlCommand("select  count(*) from paciente where usuario_id ="+ id + ";", conn);
                        SqlDataAdapter adap_count = new SqlDataAdapter(cmd_count);
                        adap_count.Fill(count, "tabla");
                        
                        contar= Convert.ToInt32(count.Tables["tabla"].Rows[0][0]);

                        if (contar != 0)
                        {
                            SqlCommand comprobar = new SqlCommand("select usuario_id from paciente where usuario_id='" + id + "';", conn);
                            SqlDataAdapter adap2 = new SqlDataAdapter(comprobar);
                            adap2.Fill(dse, "tabla");
                            try
                            {

                                comp = dse.Tables["tabla"].Rows[0]["usuario_id"].ToString();
                                if (id.Equals(comp))
                                {
                                    conn.Close();
                                }
                                else
                                {
                                    SqlCommand cmd1 = new SqlCommand("Insert into paciente(usuario_id)values(" + id + ");", conn); ;
                                    cmd1.ExecuteNonQuery();

                                    conn.Close();
                                }

                            }
                            catch (SqlException ex) { }
                        }
                        else
                        {
                            SqlCommand cmd1 = new SqlCommand("Insert into paciente(usuario_id)values(" + id + ");", conn); ;
                            cmd1.ExecuteNonQuery();

                            conn.Close();
                            conn.Close();
                        }


                        
                        conn.Close();

                        break;
                    case "2":

                        conn.Close();
                        break;
                    case "3":
                        conn.Open();
                        SqlCommand cmd_count3 = new SqlCommand("select  count(*) from asistente where usuario_id =" + id + ";", conn);
                        SqlDataAdapter adap_count3 = new SqlDataAdapter(cmd_count3);
                        adap_count3.Fill(count, "tabla");

                        contar = Convert.ToInt32(count.Tables["tabla"].Rows[0][0]);

                        if (contar != 0)
                        {

                            SqlCommand comprobar3 = new SqlCommand("select usuario_id from asistente where usuario_id='" + id + "';", conn);
                            SqlDataAdapter adap3 = new SqlDataAdapter(comprobar3);
                            adap3.Fill(dse, "tabla");
                            try
                            {
                                comp = dse.Tables["tabla"].Rows[0]["usuario_id"].ToString();
                                if (id.Equals(comp))
                                {
                                    conn.Close();
                                }
                                else
                                {
                                    SqlCommand cmd3 = new SqlCommand("Insert into asistente(usuario_id)values(" + id + ");", conn); ;
                                    cmd3.ExecuteNonQuery();

                                    conn.Close();
                                }
                            }
                            catch (SqlException ex) { }
                        }
                        else
                        {
                            SqlCommand cmd3 = new SqlCommand("Insert into asistente(usuario_id)values(" + id + ");", conn); ;
                            cmd3.ExecuteNonQuery();
                            conn.Close();
                        }
                        
                        conn.Close();
                        break;
                    case "4":
                        conn.Open();
                        SqlCommand cmd_count4 = new SqlCommand("select  count(*) from doctor where usuario_id =" + id + ";", conn);
                        SqlDataAdapter adap_count4 = new SqlDataAdapter(cmd_count4);
                        adap_count4.Fill(count, "tabla");

                        contar = Convert.ToInt32(count.Tables["tabla"].Rows[0][0]);

                        if (contar != 0)
                        {
                            SqlCommand comprobar4 = new SqlCommand("select usuario_id from doctor where usuario_id='" + id + "';", conn);
                            SqlDataAdapter adap4 = new SqlDataAdapter(comprobar4);
                            adap4.Fill(dse, "tabla");
                            try
                            {
                                comp = dse.Tables["tabla"].Rows[0]["usuario_id"].ToString();
                                if (id.Equals(comp))
                                {
                                    conn.Close();
                                }
                                else
                                {
                                    SqlCommand cmd4 = new SqlCommand("Insert into doctor(usuario_id)values(" + id + ");", conn); ;
                                    cmd4.ExecuteNonQuery();

                                    conn.Close();
                                }
                            }
                            catch (SqlException ex) { }
                        }
                        else
                        {
                            SqlCommand cmd4 = new SqlCommand("Insert into doctor(usuario_id)values(" + id + ");", conn); ;
                            cmd4.ExecuteNonQuery();
                            conn.Close();
                        }
                        
                        
                        conn.Close();
                        break;
                    case "5":
                        conn.Close();
                        break;
                    default:
                        conn.Close();
                        break;
                }
                
            }
            catch (SqlException ex)
            {

            }
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

