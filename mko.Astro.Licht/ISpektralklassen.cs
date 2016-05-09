using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro.Licht
{
    public interface ISpektralklassen
    {
        // Zugriff auf die jeweilige Spektralklasse über eine Eigenschaft
        ISpektralklasse O { get; }
        ISpektralklasse B { get; }
        ISpektralklasse A { get; }
        ISpektralklasse F { get; }
        ISpektralklasse G { get; }
        ISpektralklasse K { get; }
        ISpektralklasse M { get; }
        ISpektralklasse L { get; }
        ISpektralklasse T { get; }
        ISpektralklasse Y { get; }
        ISpektralklasse R { get; }
        ISpektralklasse N { get; }
        ISpektralklasse S { get; }

        /// <summary>
        /// Zugriff auf Spektralklasse über ihre ID mittels eines Indexers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ISpektralklasse this[SpektralklasseID id] { get; }
    }
}
