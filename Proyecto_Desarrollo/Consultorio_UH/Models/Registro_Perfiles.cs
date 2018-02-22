using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultorio_UH.Models
{
    public class Registro_Perfiles
    {
        public int rol_id { get; set; }
        public Int32 identificacion { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public DateTime fecha_nac { get; set; }
        public char sexo { get; set; }
        public string estado_civil { get; set; }
        public string telefono { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccion_detallada { get; set; }
        public string tipo_sangre { get; set; }
       
    }
}