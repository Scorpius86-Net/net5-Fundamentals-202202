using Net5.Fundamentals.AspNet.Data.Entities;
using Net5.Fundamentals.AspNet.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly IDatabase _database;

        public CustomerRepository(IDatabase database)
        {
            _database = database;
        }

        public List<Customer> List()
        {
            List<Customer> customers = new List<Customer>();
            string query = @"
                SELECT [customer_id] CustomerId
                      ,[first_name] FirstName
                      ,[last_name] LastName
                      ,[phone] Phone
                      ,[email] Email
                      ,[street] Street
                      ,[city] City
                      ,[state] State
                      ,[zip_code] ZipCode
                  FROM [sales].[customers]
            ";

            customers = _database.GetAll<Customer>(query,CommandType.Text);

            return customers;
        }
    }
}
