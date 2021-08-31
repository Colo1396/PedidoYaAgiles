using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Model
{
    public class Producto
    {
        // idProducto, nombre, descripcion, foto, precio, visible, idComercio
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string foto { get; set; }
        public double precio { get; set; }
        public bool visible { get; set; }


    }
}
