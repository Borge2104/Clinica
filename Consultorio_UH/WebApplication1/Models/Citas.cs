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
    public class Citas
    {
        public string servicio { get; set; }
        public string fecha { get; set; }

        public  DataSet ds;
    }
}