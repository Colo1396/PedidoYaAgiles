using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IProvinciaRepository
    {
        Task<IEnumerable<Provincia>> GetAllProvincias();
        Task<Provincia> GetProvincia(int idProvincia);
        Task<bool> InsertAuto(Provincia provincia);
        Task<bool> UpdatetAuto(Provincia provincia);
        Task<bool> DeleteAuto(Provincia provincia);
    }
}
