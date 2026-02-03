using System.Security.Principal;
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

        public void openConnection() => connection.openConnection();
        public void closeConnection() => connection.closeConnection();
        public void beginTransaction() => connection.beginTransaction();
        public void Commit() => connection.Commit();
        public void Rollback() => connection.Rollback();

        public void Add(IEntity obj)
        {
            using SqlCommand cmd = connection.createCommand();
            cmd.CommandText = $"INSERT INTO {obj.TableName} ({obj.Columns}) VALUES ({obj.ValuesClause})";

            foreach (var param in obj.GetParameters())
            {
                cmd.Parameters.Add(param);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
