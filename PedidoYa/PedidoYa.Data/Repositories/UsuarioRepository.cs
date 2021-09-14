using MySql.Data.MySqlClient;
using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MySQLConfiguration _connectionString;
        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUsuarioForId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatetUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

    }
}
