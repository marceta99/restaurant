using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker broker = new Broker();

        //primena template method patterna

        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                Execute();
                broker.Commit();
            }catch(Exception ex)
            {
                broker.RollBack();
            }
            finally
            {
                broker.CloseConnection();
            }
        }
        protected abstract void Execute();

    }
}
