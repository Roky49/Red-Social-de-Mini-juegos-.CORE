using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("Juego")]
    public class Juego
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Tipo")]
        public int Tipo { get; set; }
        [Column("Nveces")]
        public int Nveces { get; set; }
        [Column("Valoracion")]
        public int Valoracion { get; set; }

        [Column("ValoracionTotal")]
        public float ValoracionTotal { get; set; }


        [Column("imagen")]
        public String Imagen { get; set; }
        //[AllowHtml]
        [Column("css")]
        public String Css { get; set; }
        //[AllowHtml]
        [Column("scritp")]
        public String Scritp { get; set; }
        //[AllowHtml]
        [Column("html")]
        public String Html { get; set; }
    }
}
