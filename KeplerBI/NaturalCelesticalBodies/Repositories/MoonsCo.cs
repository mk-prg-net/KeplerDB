using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public abstract class MoonsCo : mko.BI.Repositories.BoCoBase<IMoon, string>
    {
        public MoonsCo() : base(new SortName(false)) { }

        //public override Func<IMoon, bool> GetBoIDTest(string id)
        //{
        //    return r => r.Name == id;
        //}

        public class SortName : mko.BI.Repositories.DefSortOrderCol<IMoon, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }



        public abstract mko.Algo.Interval<double> DiameterFlt { get; set; }

        public abstract bool DiameterFilterOn { get; set; }
        
    }
}
