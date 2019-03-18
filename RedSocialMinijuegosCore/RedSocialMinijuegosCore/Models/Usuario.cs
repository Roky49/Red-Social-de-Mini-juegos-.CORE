using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
   
    public class Usuario
    {

     
        public int IdUsuario { get; set; }
     
        public string Email { get; set; }
      
        public byte[] PassWord { get; set; }
 
        public int Gemas { get; set; }
     
        public int Puntuacion { get; set; }
    
        public DateTime UltimaConexion { get; set; }
    

        public string Nombre { get; set; }

        public string Salt { get; set; }
 
        public string Roles { get; set; }
    }
}

