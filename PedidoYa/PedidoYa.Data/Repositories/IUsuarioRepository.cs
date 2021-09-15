using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuario();
        Task<Usuario> GetUsuarioForId(int idUsuario);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdatetUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(Usuario usuario);
        int Login(string username,string password);
    }
}
