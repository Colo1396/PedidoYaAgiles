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
    public class PedidoRepository : IPedidoRepository

    {
        //Mysql
        private MySQLConfiguration _connectionString;
        public PedidoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        //Metodos
        public List<Pedido> GetAllPedido()
        {
            var db = dbConnection();
            var sql = @"SELECT idpedido, idComercio, descripcion, direccion, comentarios, estado FROM pedido";
            return db.Query<Pedido>(sql, new { }).ToList();
        }

        public async Task<Pedido> GetPedidoForId(int idPedido)
        {
            var db = dbConnection();

            var sql = @"select idpedido, idComercio, descripcion, direccion, comentarios, estado FROM pedido
                        where idPedido = @IdPedido";

            return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { IdPedido = idPedido });

        }

        public async Task<bool> InsertPedido(Pedido pedido)
        {
            var db = dbConnection();

            var sql = @"insert into pedido (idComercio, descripcion, direccion, comentarios, estado) 
                        values (@IdComercio,@Descripcion,@Direccion,@Comentarios,@Estado)";

            var result = await db.ExecuteAsync(sql, new { pedido.idComercio, pedido.descripcion, pedido.direccion, pedido.comentarios, pedido.estado});
            return result > 0;
        }

        public async Task<bool> UpdatetEstadoPedido(Pedido pedido, string estado)
        {
            var db = dbConnection();

            var sql = @"update pedido 
                             set estado= @Estado
                        where idPedido = @IdPedido";

            var result = await db.ExecuteAsync(sql, new { Estado = estado, IdPedido = pedido.idPedido });
            return result > 0;
        }

        public async Task<bool> UpdatetPedido(Pedido pedido)
        {
            var db = dbConnection();

            var sql = @"update pedido 
                             set idComercio= @IdComercio,
                             descripcion= @Descripcion,
                             direccion=@Direccion,
                             comentarios=@Comentarios,
                             estado=@Estado
                        where idPedido = @IdPedido";

            var result = await db.ExecuteAsync(sql, new { pedido.idComercio, pedido.descripcion, pedido.direccion, pedido.comentarios, pedido.estado, IdPedido = pedido.idPedido });
            return result > 0;
        }
        public async Task<bool> DeletePedido(Pedido pedido)
        {
            var db = dbConnection();

            var sql = @"Delete
                        from pedido 
                        where idPedido = @IdPedido";

            var result = await db.ExecuteAsync(sql, new { IdPedido = pedido.idPedido });
            return result > 0;
        }
    }
}
