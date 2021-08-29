using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Model
{
    public class Localidad
    {
        public int idLocalidad { get; set; }
        public string nombre { get; set; }
        public  Provincia provincia { get; set; }
    }
}
