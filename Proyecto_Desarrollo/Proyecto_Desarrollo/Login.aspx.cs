using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Desarrollo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lblerror.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bd bd = new bd();

            Boolean ver=bd.verificar_usuario(TextBox1.Text, TextBox2.Text);
            //string pass = bd.verificar_usuarios(TextBox1.Text, TextBox2.Text);

            //TextBox1.Text = pass;
            if (ver == true)
            {
                Response.Redirect("Administrador.aspx");
            }
            else
            {
                Lblerror.Text = "Correo o contraseña incorrecto";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
    }
}