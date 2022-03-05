using Dapper;
using Microsoft.Extensions.Configuration;
using Net5.Fundamentals.AspNet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.AspNet.Data.Helpers
{
    public class Database : IDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionStringName = "BikeStoresConnection";
        private readonly string _connectionString;

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(_connectionStringName);
        }

        public int Execute(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    using (IDbTransaction tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Execute(sql, commandType: commandType, transaction: tran);
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                    {
                        db.Close();
                    }
                }

                return result;
            }
        }

        public T Get<T>(string sql, CommandType commandType = CommandType.StoredProcedure)
        {            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(sql, commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string sql,CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(sql, commandType).ToList();
            }            
        }
        public T Insert<T>(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    using (IDbTransaction tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sql, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                    {
                        db.Close();
                    }
                }

                return result;
            }
        }
        public T Update<T>(string sql, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    using (IDbTransaction tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sql, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                    {
                        db.Close();
                    }
                }

                return result;
            }
        }
    }
}
