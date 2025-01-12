﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Model
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public string comentarios { get; set; }
        public string estado { get; set; }
        public int idComercio { get; set; }
        public int calificacion { get; set; }

        public DateTime fechaHoraPedido { get; set; }
        public string opinion { get; set; }
    }
}
