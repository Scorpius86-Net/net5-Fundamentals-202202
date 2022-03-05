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

namespace Net5.Fundamentals.AspNet.Data.Helpers
{
    public class Database : IDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionStringName = "BikeStoresConnection";
        private readonly string _connectionString;

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(_connectionStringName);
        }

        public List<T> GetAll<T>(string sql,CommandType commandType = CommandType.StoredProcedure)
        {
            List<T> entities = new List<T>();            

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                entities = db.Query<T>(sql, commandType).ToList();
            }

            return entities;
        }
    }
}
