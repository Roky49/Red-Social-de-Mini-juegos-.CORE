using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Models
{
 
    public class Producto
    {
      
        public int IdProducto { get; set; }
      
        public String Nombre { get; set; }
    
        public float Precio { get; set; }
      
        public int Stok { get; set; }
    }
}
