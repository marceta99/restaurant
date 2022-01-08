using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]

    public class NarucenaStavka
    {
        public int BrojNarucenihPorcija { get; set; }
        public StavkaCenovnika StavkaCenovnika { get; set; }

        public override string ToString()
        {
            return this.StavkaCenovnika.ToString();
        }
    }
}
