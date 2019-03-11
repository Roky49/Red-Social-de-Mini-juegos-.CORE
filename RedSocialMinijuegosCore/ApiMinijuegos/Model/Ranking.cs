using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("RANKING")]
    public class Ranking
    {

        [Key]
        [Column("Clave")]
        public int Clave { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("NombreJuego")]
        public String NombreJuego { get; set; }
        [Column("Puntuacion")]
        public int Puntuacion { get; set; }
        [Column("Imagen")]
        public String Imagen { get; set; }
        [Column("valoracionTotal")]
        public float ValoracionTotal { get; set; }
        [Column("IdPartida")]
        public int IdPartida { get; set; }

    }
}
