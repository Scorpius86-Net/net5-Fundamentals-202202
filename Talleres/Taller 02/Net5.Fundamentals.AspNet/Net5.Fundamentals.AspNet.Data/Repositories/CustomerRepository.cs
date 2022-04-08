using Net5.Fundamentals.AspNet.Data.Entities;
using Net5.Fundamentals.AspNet.Data.Helper;
using System;
using System.Collections.Generic;
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
            customers = _database.GetAll();

            return customers;
        }
    }
}
