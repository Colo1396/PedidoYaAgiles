using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IAutoRepository
    {
        //Elemento asincrono
        Task<IEnumerable<Auto>> GetAllAutos();
        Task<Auto> GetAuto(int idAuto);
        Task<bool> InsertAuto(Auto auto);
        Task<bool> UpdatetAuto(Auto auto);
        Task<bool> DeleteAuto(Auto auto);

    }
}
