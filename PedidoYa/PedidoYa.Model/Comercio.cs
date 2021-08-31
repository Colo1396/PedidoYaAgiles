using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Model
{
    public class Comercio
    {
        //idComercio, nombre, direccion, localidad, telefono, calificacion, logo
        public int idComercio { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string telefono { get; set; }
        public double calificacion { get; set; }
        public string logo { get; set; }
    }
}
