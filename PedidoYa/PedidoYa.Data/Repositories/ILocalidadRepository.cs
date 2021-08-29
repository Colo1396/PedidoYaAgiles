using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface ILocalidadRepository
    {
        Task<IEnumerable<Localidad>> GetAllLocalidad();
        Task<Localidad> GetLocalidad(int idLocalidad);
        Task<bool> InsertLocalidad(Localidad localidad);
        Task<bool> UpdatetLocalidad(Localidad localidad);
        Task<bool> DeleteLocalidad(Localidad localidad);

    }
}
