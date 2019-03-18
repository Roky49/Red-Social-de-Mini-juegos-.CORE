using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Model
{
    [Table("Pedido")]
    public class Pedido
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IdPedido")]
        public int IdPedido { get; set; }

        [Column("IdUsuarios")]
        public int IdUsuario { get; set; }

        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Pago")]
        public int Pago { get; set; }

        [Column("Proceso")]
        public String Proceso { get; set; }


    }
}
