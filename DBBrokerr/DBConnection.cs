using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DBBroker
{
    public class DBConnection : IDisposable
    {
        private SqlConnection connection;
        private SqlTransaction transaction;
        private bool disposed = false;

        public DBConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Konekcija nije inicijalizovana.");
            }
            if (connection.State == System.Data.ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void BeginTransaction()
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Konekcija nije inicijalizovana.");
            }
            if (transaction != null)
            {
                throw new InvalidOperationException("Transakcija je već započeta.");
            }
            if (connection.State != ConnectionState.Open)
            {
                throw new InvalidOperationException("Konekcija mora biti otvorena pre pokretanja transakcije!");
            }
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction == null)
            {
                throw new InvalidOperationException("Nema aktivne transakcije za potvrdu.");
            }
            try
            {
                transaction.Commit();
            }
            finally
            {
                transaction.Dispose();
                transaction = null;
            }
        }
        public void Rollback()
        {
            if (transaction == null)
            {
                throw new InvalidOperationException("Nema aktivne transakcije za poništavanje.");
            }
            try
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                transaction = null;
            }
        }
        public SqlCommand CreateCommand()
        {
            if (connection == null)
            {
                throw new InvalidOperationException("Konekcija nije inicijalizovana.");
            }
            SqlCommand cmd = new SqlCommand("", connection);

            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }

            return cmd;
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
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        connection.Dispose();
                        connection = null;
                    }
                }
                disposed = true;
            }
        }
        ~DBConnection()
        {
            Dispose(false);
        }
    }
}

