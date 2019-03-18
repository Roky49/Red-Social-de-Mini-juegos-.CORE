
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
    
    public class Evento
    {
       
        public int IdEvento { get; set; }

        
        public int IdUsuario { get; set; }

        
        public int Coste { get; set; }
      
        public int Premio { get; set; }

     
        public String Juego { get; set; }
       
        public String Tipo { get; set; }
    }
}
