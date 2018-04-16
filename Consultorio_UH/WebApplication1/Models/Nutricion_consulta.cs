using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Consultorio_UH.Models;
using System.Globalization;
using Consultorio_UH.Security;
using System.ComponentModel.DataAnnotations;
namespace Consultorio_UH.Models
{
    public class Nutricion_consulta
    {

        public int cita_id { get; set; }
        [Required(ErrorMessage = "*Diagnostico")]
        public string diagnostico { get; set; }

        [Required(ErrorMessage = "*Genero")]
        public string genero { get; set; }

        [Required(ErrorMessage = "*Edad")]
        public string Edad { get; set; }

        [Required(ErrorMessage = "*Peso actual")]
        public double peso { get; set; }

        [Required(ErrorMessage = "*Peso usual")]
        public double peso_usual { get; set; }

        [Required(ErrorMessage = "*Circunferencia de Muñeca")]
        public double circun_muneca { get; set; }

        [Required(ErrorMessage = "*Altura Rodilla")]
        public double Altura_rod { get; set; }

        [Required(ErrorMessage = "*Circunferencia Braquial")]
        public double circun_braquial { get; set; }
        [Required(ErrorMessage = "*Circunferencia de Abdominal")]
        public double circun_abdominal { get; set; }

        [Required(ErrorMessage = "*Circunferencia de Cadera")]
        public double circun_Cadera { get; set; }

        [Required(ErrorMessage = "*% Grasa")]
        public int porc_grasa { get; set; }

        
        public double Talla_utilizar { get; set; }
        
        public double PI { get; set; }

        
        public double IMC_Deseado { get; set; }

        /*Valores por formulas*/

        /*PASO 1*/
        public double talla_h { get; set; }
        public double talla_m { get; set; }

        /*PASO 2*/
        public double estructura_c { get; set; }
        public double imc { get; set; }
        

        public double ec_peq_h { get; set; }
        public double ec_peq_m { get; set; }

        public double ec_med_h { get; set; }
        public double ec_med_m { get; set; }

        public double ec_gra_h { get; set; }
        public double ec_gra_m { get; set; }

        public double peq_fec { get; set; }
        public double med_fec { get; set; }
        public double gra_fec { get; set; }

        public double adult_mayor_medida { get; set; }

        public double pi_lorentz_h { get; set; }
        public double pi_lorentz_m { get; set; }

        public double pi_raza_b_h { get; set; }
        public double pi_raza_b_m { get; set; }
        public double pi_raza_n_h { get; set; }
        public double pi_raza_n_m { get; set; }

        /*PASO 3*/
        public double pt { get; set; }
        public double pu { get; set; }

        public double cp { get; set; }

        public double grasa_h { get; set; }
        public double grasa_m { get; set; }
        public double peso_ajustado { get; set; }
        public double peso_imc { get; set; }
        public double peso_meta { get; set; }

        /*Variables BD*/
        public DataTable ds = new DataTable();
        private SqlConnection conn = new SqlConnection("Data Source=uhclinica.database.windows.net;Initial Catalog=UHConsulta;Persist Security Info=True;User ID=db_root;Password=Uhispano2018");

        public void paso_1()
        {
            /*Estimacion de talla*/
            talla_h = 64.19 - (0.04 * Convert.ToDouble(Edad)) + (2.02 * Altura_rod);
            talla_m = 84.88 - (0.24 * Convert.ToDouble(Edad)) + (1.83 * Altura_rod);
        }
        public void paso_2()
        {
            estructura_c = Talla_utilizar / circun_muneca;
            imc = peso / ((Talla_utilizar / 100) * (Talla_utilizar / 100));
            /*PI segun ADA*/
            ec_med_h = ((Talla_utilizar - 152) / (2.5)*(2.7)+(48.2));
            ec_peq_h = ec_med_h - (ec_med_h*0.1);
            ec_gra_h = ec_med_h + (ec_med_h * 0.1);

            ec_med_m = ((Talla_utilizar - 152) / (2.5) * (2.3) + (45.5));
            ec_peq_m = ec_med_m - (ec_med_m * 0.1);
            ec_gra_m = ec_med_m + (ec_med_m * 0.1);

            /*PI segun FEC*/;
            peq_fec = (((Talla_utilizar / 100) * (Talla_utilizar / 100))*20.5);
            med_fec = (((Talla_utilizar / 100) * (Talla_utilizar / 100)) * 22.5);
            gra_fec = (((Talla_utilizar / 100) * (Talla_utilizar / 100)) * 25);
            /*PI segun IMC Adulto mayor*/

            adult_mayor_medida = ((23* ((Talla_utilizar / 100) * (Talla_utilizar / 100))) +(28* ((Talla_utilizar / 100) * (Talla_utilizar / 100))))/(2);
            /*PI por formula de Lorentz*/
            pi_lorentz_h = Talla_utilizar - 100 - ((Talla_utilizar - 150) / 4);
            pi_lorentz_m = Talla_utilizar - 100 - ((Talla_utilizar - 150) / 2.5);

            /*Estimacion PI pte encamada*/
            /*Raza blanca*/
            pi_raza_b_h = (Altura_rod * 1.1) + (circun_braquial * 3.07) - 75.81;
            pi_raza_b_m = (Altura_rod * 1.09) + (circun_braquial * 2.68) - 65.51;
            /*Raza Negra*/
            pi_raza_n_h = (Altura_rod * 0.44) + (circun_braquial * 2.86) - 39.21;
            pi_raza_n_m = (Altura_rod * 1.5) + (circun_braquial * 2.58) - 84.22;


        }
        public void paso_3()
        {
            /*Pesos*/
            peso_ajustado = (peso - PI) / (4) + PI;
            peso_imc = IMC_Deseado * ((Talla_utilizar / 100) * (Talla_utilizar / 100));
            peso_meta = peso - (ec_med_h * 0.1);

            /*Porcentajes*/
            pt = (peso / PI) * 100;
            pu = (peso / peso_usual) * 100;
            cp = (((peso_usual) - peso)*100)/peso_usual;
            grasa_h = (1.2 * imc) + (0.23 * Convert.ToDouble(Edad)) - (10.8 * 1) - 5.4;
            grasa_m = (1.2 * imc) + (0.23 * Convert.ToDouble(Edad)) - 0 - 5.4;

        }

    }
}