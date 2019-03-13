using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("MostrarPerfil")]
    public class MostrarPerfil
    {
        [Key]
        [Column("Clave")]
        public int Clave { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("NombreJuego")]
        public String NombreJuego { get; set; }
      
        [Column("Imagen")]
        public String Imagen { get; set; }
       
        [Column("Total")]
        public int Total { get; set; }

        
  
    }
}
