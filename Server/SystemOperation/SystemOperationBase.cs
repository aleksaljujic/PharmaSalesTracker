using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBBroker;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase
    {
        protected Broker broker;

        public SystemOperationBase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ApotekaDB"].ConnectionString;
            broker = new Broker(connectionString);
        }

        public void Execute()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteOperation();

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw new Exception("Greška pri izvršavanju operacije: " + ex.Message, ex);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteOperation();
    }
}
