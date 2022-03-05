using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Net5.Fundamentals.AspNet.Data.Helpers
{
    public interface IDatabase
    {
        List<T> GetAll<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
    }
}