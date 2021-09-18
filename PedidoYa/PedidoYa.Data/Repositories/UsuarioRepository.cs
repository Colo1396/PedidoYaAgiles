using Dapper;
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

        public async Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            var db = dbConnection();

            var sql = @"select id, username, password from usuario";

            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<Usuario> GetUsuarioForId(int idUsuario)
        {
            var db = dbConnection();

            var sql = @"select id, username, password from usuario
                        where id = @Id";

            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = idUsuario });
        }

        public int InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"insert into usuario (username, password) 
                        values (@Username,@Password); select LAST_INSERT_ID();";

            int id = db.ExecuteScalar<int>(sql, new { usuario.username, usuario.password });
            return id;
        }

        public async Task<bool> UpdatetUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"update usuario 
                             set username= @Username,
                             password= @Password
                        where id = @Id";

            var result = await db.ExecuteAsync(sql, new { usuario.username, usuario.password, usuario.id });
            return result > 0;
        }

        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from usuario 
                        where id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = usuario.id });
            return result > 0;
        }

        public int Login(string username, string password)
        {
            var db = dbConnection();

            var sql = @"select id from usuario where username=@Username and password= @Password";

            return db.QueryFirstOrDefault<int>(sql, new { Username = username, Password = password });

        }
    }

}
