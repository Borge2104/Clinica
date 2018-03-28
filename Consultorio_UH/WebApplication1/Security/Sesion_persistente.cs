using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio_UH.Security
{
    public static class Sesion_persistente
    {

        static string usuario_sesion_var = "Usuario";
        static string Nombre_logueado_var = "";
        static string rol_id = "0";

        public static string Nombre_logueado
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sesion_var = HttpContext.Current.Session[Nombre_logueado_var];
                if (sesion_var != null)
                    return sesion_var as string;
                return null;


            }

            set
            {
                HttpContext.Current.Session[Nombre_logueado_var] = value;
            }
        }
        public static string Usuario
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sesion_var = HttpContext.Current.Session[usuario_sesion_var];
                if (sesion_var != null)
                    return sesion_var as string;
                return null;

                
            }

            set
            {
                HttpContext.Current.Session[usuario_sesion_var] = value;
            }
        }
        public static string Rol_id
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sesion_var = HttpContext.Current.Session[rol_id];
                if (sesion_var != null)
                    return sesion_var as string;
                return null;


            }
            set
            {
                HttpContext.Current.Session[rol_id] = value;
            }
        }

    }
}