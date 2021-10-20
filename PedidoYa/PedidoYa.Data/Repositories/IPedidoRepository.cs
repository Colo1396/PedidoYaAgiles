using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IPedidoRepository
    {
        List<Pedido> GetAllPedido();
        Task<Pedido> GetPedidoForId(int idPedido);
        Task<Pedido> PedidosXComercio(int idComercio);
        Task<bool> InsertPedido(Pedido pedido, int idComercio);
        Task<bool> UpdatetPedido(Pedido pedido, int idComercio);
        Task<bool> UpdatetEstadoPedido(Pedido pedido, string estado);
        Task<bool> DeletePedido(Pedido pedido);

    }
}
