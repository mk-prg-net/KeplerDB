using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public abstract class CometsCo : mko.BI.Repositories.BoCoBase<IComet, string>
    {
        public class SortName : mko.BI.Repositories.DefSortOrderCol<IComet, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        public CometsCo() : base(new SortName(false)) { }

        public override Func<IComet, bool> GetBoIDTest(string id)
        {
            return r => r.Name == id;
        }
    }
}
