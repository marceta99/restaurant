using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDomainObjekat
    {
         string ImeTabele { get;  }
         string InsertVrednosti { get;}
         string Id { get; }
         string Where { get; set; }
         string Set { get; set; }
         string JoinTableName { get; set; }
         string JoinFirst { get; set; }
         string JoinSecond { get; set; }
         string JoinSecondTableName { get; set; }
         string JoinJoinON { get; set; }
        IDomainObjekat ProctiajRedTabele(SqlDataReader reader);
    }
}
