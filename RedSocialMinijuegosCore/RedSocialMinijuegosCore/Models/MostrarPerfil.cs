using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
  
    public class MostrarPerfil
    {
     
        public Int64 Clave { get; set; }
       
        public String Nombre { get; set; }
        
        public String NombreJuego { get; set; }
      
       
        public String Imagen { get; set; }
       
      
        public int Total { get; set; }

        
  
    }
}
