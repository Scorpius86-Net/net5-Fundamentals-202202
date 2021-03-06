using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    public interface ICustomerRepository
    {
        bool Exists(int customerId);
        Customer Get(int customerId);
        Customer Insert(Customer customer);
        List<Customer> List();
        int Remove(int customerId);
        Customer Update(Customer customer);
    }
}