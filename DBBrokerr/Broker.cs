using System.Data.Common;
using System.Security.Principal;
using Common.Domain;
using Microsoft.Data.SqlClient;

namespace DBBroker
{
    public class Broker : IDisposable
    {
        private DBConnection connection;
        private bool disposed = false;

        public Broker(string connectionString)
        {
            connection = new DBConnection(connectionString);
        }

        public void OpenConnection() => connection.OpenConnection();
        public void CloseConnection() => connection.CloseConnection();
        public void BeginTransaction() => connection.BeginTransaction();
        public void Commit() => connection.Commit();
        public void Rollback() => connection.Rollback();

        public void Add(IEntity obj)
        {
            using SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"INSERT INTO {obj.TableName} ({obj.Columns}) VALUES ({obj.ValuesClause})";

            foreach (var param in obj.GetSqlParameters())
            {
                cmd.Parameters.Add(param);
            }
            cmd.ExecuteNonQuery();
        }

        public int AddWithReturnId(IEntity obj)
        {
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {obj.TableName} ({obj.Columns}) OUTPUT INSERTED.{obj.PrimaryKey} VALUES ({obj.ValuesClause})";
            foreach (var param in obj.GetSqlParameters())
            {
                cmd.Parameters.Add(param);
            }
            return (int)cmd.ExecuteScalar();
        }

        public void Update(IEntity obj)
        {
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE {obj.TableName} SET {obj.SetClause} WHERE {obj.PrimaryKeyCondition}";
            foreach (var param in obj.GetSqlParameters())
            {
                cmd.Parameters.Add(param);
            }
            foreach (var pkParam in obj.GetPrimaryKeyParameters())
            {
                cmd.Parameters.Add(pkParam);
            }
            cmd.ExecuteNonQuery();
        }

        public void Delete(IEntity obj)
        {
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {obj.PrimaryKeyCondition}";
            foreach (var pkParam in obj.GetPrimaryKeyParameters())
            {
                cmd.Parameters.Add(pkParam);
            }
            cmd.ExecuteNonQuery();
        }

        public List<IEntity> GetAll(IEntity filter)
        {
            using var cmd = connection.CreateCommand();

            string tableName = !string.IsNullOrEmpty(filter.JoinTableName)
                ? filter.JoinTableName
                : filter.TableName;

            string selectClauses = filter.SelectClaues ?? "*";

            cmd.CommandText = $"SELECT {selectClauses} FROM {tableName}";

            using var reader = cmd.ExecuteReader();

            return filter.GetReaderList(reader);
        }

        public List<IEntity> GetByFilter(IEntity filter)
        {
            using var cmd = connection.CreateCommand();
            string tableName = !string.IsNullOrEmpty(filter.JoinTableName)
                ? filter.JoinTableName
                : filter.TableName;

            string selectClauses = filter.SelectClaues ?? "*";
            var (whereClause, parameters) = filter.GetWhereClauseWithParameters();

            cmd.CommandText = $"SELECT {selectClauses} FROM {tableName}";

            Console.WriteLine("=== DEBUG SQL ===");
            Console.WriteLine(cmd.CommandText);

            if (!string.IsNullOrEmpty(whereClause))
            {
                cmd.CommandText += $" WHERE {whereClause}";
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
            }
            using var reader = cmd.ExecuteReader();
            return filter.GetReaderList(reader);
        }

        public int? GetFirstId(IEntity obj)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT TOP 1 {obj.PrimaryKey} FROM {obj.TableName}";

            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return null;
        }
        public T ExecuteScalar<T>(string sql, params SqlParameter[] args)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            foreach (var param in args)
            {
                cmd.Parameters.Add(param);
            }
            object? result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
            {
                return default!;
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (connection != null)
                    {
                        connection.Dispose();
                    }
                }
                disposed = true;
            }
        }

        ~Broker()
        {
            Dispose(false);
        }

    }
    }

