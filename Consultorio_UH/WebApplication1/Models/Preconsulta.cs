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
    public class Preconsulta
    {
        
        [Required(ErrorMessage = "*Estatura")]        
        public double Estatura { get; set; }
        [Required(ErrorMessage = "*Peso")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "*Presion")]
        [Range(0, 200, ErrorMessage = "*Valores entre 0-200")]
        public int Presion { get; set; }

        [Required(ErrorMessage = "*Motivo")]
        public string Motivo { get; set; }

        SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");
        public DataSet ds;
    }
}