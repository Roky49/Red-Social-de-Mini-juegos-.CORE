using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
  
    public class Ranking
    {

       
        public Int64 Clave { get; set; }
       
        public String Nombre { get; set; }
      
        public String NombreJuego { get; set; }
       
        public int Puntuacion { get; set; }
    
        public String Imagen { get; set; }
      
        public double ValoracionTotal { get; set; }
    
        public int IdPartida { get; set; }

    }
}
