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
        private string ConnectionString = "BikesStoreConnection";

        public Database(IConfiguration config)
        {
            _config = config;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            string sql = @"
                SELECT [customer_id] CustomerId
                    ,[first_name] FirstName
                    ,[last_name] LastName
                    ,[phone] Phone
                    ,[email] Email
                    ,[street] Street
                    ,[city] City
                    ,[state] [State]
                    ,[zip_code] ZipCode
                FROM [sales].[customers]
                ORDER BY [customer_id]
            ";

            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString)))
            {
                customers = db.Query<Customer>(sql, CommandType.Text).ToList();
            }

            return customers;
        }
    }
}
