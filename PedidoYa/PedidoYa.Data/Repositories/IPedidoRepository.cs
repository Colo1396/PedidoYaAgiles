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
        List<Pedido> GetPedidoForIdCmercio(int idComercio);
        Task<Pedido> GetPedidoForId(int idPedido);
        Task<bool> InsertPedido(Pedido pedido);
        Task<bool> UpdatetPedido(Pedido pedido);
        Task<bool> UpdatetEstadoPedido(Pedido pedido, string estado);
        Task<bool> DeletePedido(Pedido pedido);

    }
}
