using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
  
    public class Partida
    {
       
        public int IdPartida { get; set; }

      
        public int IdUsuario { get; set; }

        public String NombreJuego { get; set; }

        public int Puntuacion { get; set; }

       
        public DateTime Fecha { get; set; }
    }
}
