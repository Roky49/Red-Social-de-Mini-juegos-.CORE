using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("Partida")]
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IdPartida")]
        public int IdPartida { get; set; }

        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Column("NombreJuego")]
        public String NombreJuego { get; set; }

        [Column("Puntuacion")]
        public int Puntuacion { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }
    }
}
