using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;

namespace Net5.Fundamentals.AspNet.Data.Helper
{
    public interface IDatabase
    {
        List<Customer> GetAll();
    }
}