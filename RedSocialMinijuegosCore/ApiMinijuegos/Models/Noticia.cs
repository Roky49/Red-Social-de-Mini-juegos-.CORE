using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Models
{
    [Table("TITULARES")]
    public class Noticia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDTITULAR")]
        public int IdTitular { get; set; }
        [Column("TITULO")]
        public String Titular { get; set; }
        [Column("ENLACE")]
        public String Enlace { get; set; }
        [Column("DESCRIPCION")]
        public String Descripcion { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }
}
