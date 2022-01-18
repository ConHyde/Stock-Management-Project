using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace StockManagement_Lib.DataAccess
{
    public class DBAccess : IDisposable
    {
        private DBType _dbType;
        public DBType dbType
        {
            get
            {
                return _dbType;
            }
        }
        private IConfiguration _configuration;

        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
        private SqlConnection _dbConnection ;
        public SqlConnection DBConnection
        {
            get
            {
                return _dbConnection;
            }
        }


        public DBAccess(string connectionString)
        {
            _connectionString = connectionString;
            _dbType = DBType.MSSQL;
            _dbConnection = new SqlConnection(_connectionString);
            _dbConnection.Open();
        }

        public void Dispose()
        {
            _dbConnection.Close();
        }
    }
}
