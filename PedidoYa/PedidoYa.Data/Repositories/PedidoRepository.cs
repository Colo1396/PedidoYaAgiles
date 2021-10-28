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
            var sql = @"SELECT p.* FROM pedido p";
            return db.Query<Pedido>(sql, new { }).ToList();
        }

        public async Task<Pedido> GetPedidoForId(int idPedido)
        {
            var db = dbConnection();

            var sql = @"select p.* FROM pedido p
                        where idPedido = @IdPedido";

            return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { IdPedido = idPedido });

        }
        
        public List<Pedido> PedidosXComercio(int idComercio)
        {
            var db = dbConnection();

            var sql = @"select  p.*
                        FROM pedido p
                        where p.idComercio = @IdComercio";

            return db.Query<Pedido>(sql, new { IdComercio = idComercio }).ToList();
        }

        public int InsertPedido(Pedido pedido)
        {
            var db = dbConnection();

            var sql = @"insert into pedido (idComercio, descripcion, direccion, comentarios, estado,calificacion,fechaHoraPedido,opinion) 
                        values (@IdComercio,@Descripcion,@Direccion,@Comentarios,@Estado,0,DATE_SUB(now(), INTERVAL 3 HOUR),''); select LAST_INSERT_ID();";

            var result = db.ExecuteScalar<int>(sql, new { pedido.idComercio, pedido.descripcion, pedido.direccion, pedido.comentarios, pedido.estado});
            return result;
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
                             estado=@Estado,
                            calificacion=@Calificacion,
                            opinion=@Opinion
                        where idPedido = @IdPedido";    

            var result = await db.ExecuteAsync(sql, new { pedido.idComercio, pedido.descripcion, pedido.direccion, pedido.comentarios, pedido.estado, IdPedido = pedido.idPedido,pedido.calificacion,pedido.opinion });
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

        public bool UpdatePromedioCalificacionComercio(int idComercio)
        {
            var db = dbConnection();

            var sql = @"update comercio c 
                        inner join (select case when count(*)=0 then 0 else  cast(sum(calificacion)/count(*)  as decimal(15,1))  end promCalif,idComercio from pedido group by idComercio) calif
                        on calif.idComercio= c.idComercio
                        set c.promCalificacion=calif.promCalif
                        where c.idComercio=@IdComercio";

            var result = db.Execute(sql, new { IdComercio = idComercio });
            return result > 0;
        }

    }
}
