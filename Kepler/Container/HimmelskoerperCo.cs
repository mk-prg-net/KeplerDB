using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler
{
    /// <summary>
    /// Container, in dem alle Galaxieen verwaltet werden.
    /// </summary>
    /// <typeparam name="TSpektralklasse"></typeparam>
    public abstract class HimmelskoerperCo<THk, TKey> : mko.BI.Repositories.BoCoBase<THk, TKey>
        where THk : class, IPlanet
    {
        public class SortName : mko.BI.Repositories.DefSortOrderCol<THk, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        public HimmelskoerperCo()
            : base(new SortName(true)) { }

    }
}
