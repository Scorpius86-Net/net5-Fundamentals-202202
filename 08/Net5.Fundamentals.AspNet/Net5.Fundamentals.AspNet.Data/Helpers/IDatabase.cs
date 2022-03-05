using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Net5.Fundamentals.AspNet.Data.Helpers
{
    public interface IDatabase
    {
        int Execute(string sql, CommandType commandType = CommandType.StoredProcedure);
        T Get<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sql, CommandType commandType = CommandType.StoredProcedure);
    }
}