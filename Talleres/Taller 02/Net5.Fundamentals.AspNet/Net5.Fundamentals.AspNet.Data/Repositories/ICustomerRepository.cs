using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Data.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(int customerId);
        List<Customer> List();
    }
}