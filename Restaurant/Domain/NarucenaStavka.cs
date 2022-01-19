using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]

    public class NarucenaStavka: IDomainObjekat
    {
        public int BrojNarucenihPorcija { get; set; }
        public StavkaCenovnika StavkaCenovnika { get; set; }

        public string ImeTabele{ get; set;}

        public string InsertVrednosti{ get; set;}

        public string Id{ get; set;}

        public string Where { get; set; }
        public string Set { get; set; }
        public string JoinTableName { get; set; }
        public string JoinFirst { get; set; }
        public string JoinSecond { get; set; }
        public string JoinSecondTableName { get; set; }
        public string JoinJoinON { get; set; }

        public IDomainObjekat ProctiajRedTabele(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.StavkaCenovnika.ToString();
        }
    }
}
