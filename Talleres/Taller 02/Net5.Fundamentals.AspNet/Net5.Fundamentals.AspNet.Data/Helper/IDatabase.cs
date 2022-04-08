using Dapper;
using Net5.Fundamentals.AspNet.Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace Net5.Fundamentals.AspNet.Data.Helper
{
    public interface IDatabase
    {
        T Get<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
    }
}