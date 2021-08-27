using MySql.Data.MySqlClient;
using PedidoYa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data.Repositories
{
    class ProvinciaRepository : IProvinciaRepository
    {

        private MySQLConfiguration _connectionString;
        public ProvinciaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public Task<bool> DeleteAuto(Provincia provincia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Provincia>> GetAllProvincias()
        {
            throw new NotImplementedException();
        }

        public Task<Provincia> GetProvincia(int idProvincia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAuto(Provincia provincia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatetAuto(Provincia provincia)
        {
            throw new NotImplementedException();
        }
    }
}
