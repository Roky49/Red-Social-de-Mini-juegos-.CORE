using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
  
    public class Pedido
    {

        
        public int IdPedido { get; set; }

        public int IdUsuario { get; set; }

        public int IdProducto { get; set; }

       
        public int Pago { get; set; }

        public String Proceso { get; set; }


    }
}
