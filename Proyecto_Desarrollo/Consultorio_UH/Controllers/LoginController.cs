using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio_UH.Models;
namespace Consultorio_UH.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            //Login obj = new Login();
            return View();
        }

    }
}