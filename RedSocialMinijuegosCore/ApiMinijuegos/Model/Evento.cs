using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IdEvento")]
        public int IdEvento { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Coste")]
        public int Coste { get; set; }
        [Column("Premio")]
        public int Premio { get; set; }

        [Column("Juego")]
        public String Juego { get; set; }
        [Column("Tipo")]
        public String Tipo { get; set; }
    }
}
