using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public abstract class StarsCo : mko.BI.Repositories.BoCoBase<IStar, string>
    {
        public class SortName : mko.BI.Repositories.DefSortOrderCol<IStar, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        public StarsCo() : base(new SortName(false)) { }

        public override Func<IStar, bool> GetBoIDTest(string id)
        {
            return r => r.Name == id;
        }
    }
}
