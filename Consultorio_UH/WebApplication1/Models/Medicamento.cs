using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace Consultorio_UH.Models
{
    public class Medicamento
    {
        [Required(ErrorMessage = "*Medicamento")]
        public string medicamento { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        [Required(ErrorMessage = "*dosis")]
        public int dosis { get; set; }
        [Required(ErrorMessage = "*Detalle")]
        public string detalle { get; set; }
    }
}