using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoYa.Data
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connctionString) => ConnectionString = connctionString;

        public string ConnectionString { get; set; }
    }
}
