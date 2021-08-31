using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IComercioRepository
    {
        Task<IEnumerable<Comercio>> GetAllComercios();
        Task<Comercio> GetComercioForId(int idComercio);
        Task<bool> InsertComercio(Comercio comercio);
        Task<bool> UpdatetComercio(Comercio comercio);
        Task<bool> DeleteComercio(Comercio comercio);
        Task<IEnumerable<Comercio>> GetAllComerciosXLocalidad(string localidad);
    }
}
