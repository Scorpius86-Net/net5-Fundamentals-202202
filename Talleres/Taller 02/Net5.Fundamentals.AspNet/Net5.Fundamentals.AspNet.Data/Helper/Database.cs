using Dapper;
using Microsoft.Extensions.Configuration;
using Net5.Fundamentals.AspNet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.AspNet.Data.Helper
{
    public class Database : IDatabase
    {
        private readonly IConfiguration _config;
        private string ConnectionString = "BikeStoresConnection";

        public Database(IConfiguration config)
        {
            _config = config;
        }

        public T Get<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return db.Query<T>(sql, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sql,DynamicParameters param,CommandType commandType = CommandType.StoredProcedure)
        {
            
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                return db.Query<T>(sql, commandType: commandType).ToList();
            }
        }
    }
}
