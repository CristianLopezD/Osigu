using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroVianca.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()  => _connectionString = Properties.Settings.Default.DB;
        protected SqlConnection GetConnection() => new (_connectionString);
    }
}
