
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
    
    public class Juego
    {
       
        public String Nombre { get; set; }
    
        public int Tipo { get; set; }
     
        public int Nveces { get; set; }
      
        public int Valoracion { get; set; }

       
        public Double ValoracionTotal { get; set; }


     
        public String Imagen { get; set; }
        
        public String Css { get; set; }
   
     
        public String Scritp { get; set; }
     
      
        public String Html { get; set; }
    }
}
