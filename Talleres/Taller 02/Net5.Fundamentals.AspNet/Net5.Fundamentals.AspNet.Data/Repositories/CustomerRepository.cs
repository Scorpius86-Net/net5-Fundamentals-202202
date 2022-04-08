using Net5.Fundamentals.AspNet.Data.Entities;
using Net5.Fundamentals.AspNet.Data.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
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
                    ,[state] [State]
                    ,[zip_code] ZipCode
                FROM [sales].[customers]
                ORDER BY [customer_id]
            ";

            customers = _database.GetAll<Customer>(query,null,CommandType.Text);

            return customers;
        }
        public Customer Get(int customerId)
        {
            Customer customer = new Customer();
            string query = @$"
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
                WHERE [customer_id] = {customerId}
                ORDER BY [customer_id]
            ";

            customer = _database.Get<Customer>(query, null, CommandType.Text);

            return customer;
        }
    }
}
