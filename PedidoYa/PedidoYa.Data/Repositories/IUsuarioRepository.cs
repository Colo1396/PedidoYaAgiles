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
        Usuario GetUsuarioForId(int idUsuario);
        int InsertUsuario(Usuario usuario);
        Task<bool> UpdatetUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(Usuario usuario);
        int Login(string username,string password);
        Usuario GetUsuarioForUserName(string username);
    }
}
