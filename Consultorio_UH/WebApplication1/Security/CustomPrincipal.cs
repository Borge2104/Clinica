using Consultorio_UH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Consultorio_UH.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Login Cuenta;
        

        public CustomPrincipal(Login Cuenta_p)
        {
            this.Cuenta = Cuenta_p;
            this.Identity = new GenericIdentity(Cuenta_p.Correo);
        }
        public IIdentity Identity
        {
            get;
            set;
            
        }

        public bool IsInRole(string Rol)
        {
            var Role = Rol;
            return Role.Any(r => this.Cuenta.Rol.Contains(r));
        }
    }
}