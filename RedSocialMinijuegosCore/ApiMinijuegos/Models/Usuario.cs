using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PassWord")]
        //[JsonIgnoreAttribute]
        public byte[] PassWord { get; set; }
        [Column("Gemas")]
        public int Gemas { get; set; }
        [Column("Puntiacion")]
        public int Puntuacion { get; set; }
        [Column("UltimaConexion")]
        public DateTime UltimaConexion { get; set; }
        [Column("Nombre")]

        public string Nombre { get; set; }
        [Column("Salt")]
        public string Salt { get; set; }
        [Column("Roles")]
        public string Roles { get; set; }
    }
}

