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
        Comercio GetComercioForId(int idComercio);
        bool InsertComercio(Comercio comercio);
        bool UpdateComercio(Comercio comercio);
        Task<bool> DeleteComercio(Comercio comercio);
        Task<IEnumerable<Comercio>> GetAllComerciosXLocalidad(string localidad);
        Comercio GetComercioXIdUsuario(int idUsuario);
    }
}
