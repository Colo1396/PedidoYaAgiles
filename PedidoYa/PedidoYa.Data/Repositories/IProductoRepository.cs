using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> GetAllProductos();
        Task<Producto> GetProductoForId(int idProducto);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> InsertProducto(Producto producto,int idComercio);
        Task<bool> UpdatetProducto(Producto producto);
        Task<bool> UpdatetProducto(Producto producto, int idComercio);
        Task<bool> DeleteProducto(Producto producto);
        Task<IEnumerable<Producto>> GetAllProductosXComercio(int idComercio);

    }
}
