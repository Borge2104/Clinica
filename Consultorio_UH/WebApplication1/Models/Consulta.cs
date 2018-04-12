using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Consultorio_UH.Models
{
    public class Consulta
    {
       // public int id { get; set; }
        public int cita_id { get; set; }
        //public int asistente_id { get; set; }
       // public DateTime fecha { get; set; }

        
        [Required(ErrorMessage = "*Diagnostico")]
        public string diagnostico { get; set; }

        [Required(ErrorMessage = "*Medicamento")]
        public string medicamento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        [Required(ErrorMessage = "*dosis")]
        public int dosis { get; set; }
        [Required(ErrorMessage = "*Detalle")]
        public string detalle { get; set; }

        /* public string hora { get; set; }
         [Required(ErrorMessage = "*Peso")]
         [Range(0.1, 200.0, ErrorMessage = "*Proporcione una medida correcta 0.0 kg")]
         public decimal peso { get; set; }
         [Required(ErrorMessage = "*Estatura")]
         [Range(0.1, 4.0, ErrorMessage = "*Proporcione una medida correcta 0.0 m")]
         public decimal estatura { get; set; }
         [Required(ErrorMessage = "*Presion")]
         public string presion { get; set; }*/

        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

    }
}