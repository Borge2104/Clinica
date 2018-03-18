using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Consultorio_UH.Models;
using Consultorio_UH.Security;

namespace Consultorio_UH.Security
{
    public class CustomAutorizarAtributos : AuthorizeAttribute
    {
        private Login au = new Login();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (string.IsNullOrEmpty(Sesion_persistente.Usuario))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            else
            {
                Login am = new Login();
                CustomPrincipal mp = new CustomPrincipal(au.verificar_usuario_modelo(Sesion_persistente.Usuario));
                if(!mp.IsInRole(Roles))
                    filterContext.Result=new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            }   
         
        }

    }
}