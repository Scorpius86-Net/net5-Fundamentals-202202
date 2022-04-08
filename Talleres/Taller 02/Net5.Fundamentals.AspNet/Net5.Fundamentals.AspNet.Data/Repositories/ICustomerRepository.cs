using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    public interface ICustomerRepository
    {
        bool Exists(int customerId);
        Customer Get(int customerId);
        List<Customer> List();
        Customer Update(Customer customer);
    }
}