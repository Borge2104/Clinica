using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
namespace Consultorio_UH.Models
{
    public class Correo
    {
       public string para { set; get; }
        public string pass { set; get; }

        public void Establecer_Password()
        {
            
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("uhconsulta@gmail.com");//Correo que usara la aplicacion de base.
            correo.To.Add(para);
            correo.Subject=("Establecer contraseña UHconsulta");
            //correo.Body = "Accede al siguiente enlace para establecer tu contraseña:  http://localhost:65477/Home/Establecer_password ";
            correo.Body = "Accede al siguiente enlace para establecer tu contraseña:  http://uhconsultas.azurewebsites.net/Home/Establecer_password ";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            //Configuracion Servidor smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            string CuentaCorreo = "uhconsulta@gmail.com";
            string PassCorreo = "uhconsulta2018";
            smtp.Credentials = new System.Net.NetworkCredential(CuentaCorreo, PassCorreo);
            smtp.Send(correo);
        }

        public void Restablecer_Password()
        {

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("uhconsulta@gmail.com");//Correo que usara la aplicacion de base.
            correo.To.Add(para);
            correo.Subject = ("Restablecer contraseña UHconsulta");
            //correo.Body = "Accede al siguiente enlace para Restablecer tu contraseña:  http://localhost:65477/Home/Modificar_password ";
            correo.Body = "Accede al siguiente enlace para Restablecer tu contraseña:  http://uhconsultas.azurewebsites.net/Home/Modificar_password ";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            //Configuracion Servidor smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            string CuentaCorreo = "uhconsulta@gmail.com";
            string PassCorreo = "uhconsulta2018";
            smtp.Credentials = new System.Net.NetworkCredential(CuentaCorreo, PassCorreo);
            smtp.Send(correo);
        }
        public void Notificacion()
        {
            String Notificar = "Usuario:" + para + "\n\r" +
                          "Password:" + pass;

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("uhconsulta@gmail.com");//Correo que usara la aplicacion de base.
            correo.To.Add(para);
            correo.Subject = ("Su contraseña se ha establecido");
            correo.Body = Notificar;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            //Configuracion Servidor smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            string CuentaCorreo = "uhconsulta@gmail.com";
            string PassCorreo = "uhconsulta2018";
            smtp.Credentials = new System.Net.NetworkCredential(CuentaCorreo, PassCorreo);
            smtp.Send(correo);
        }

    }
}