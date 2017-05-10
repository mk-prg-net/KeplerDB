using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Evaluierte Planets.FilterSortedSetBuilder.defMassRange- Funktion ausführen
    /// </summary>
    public class MassRngData : ConfigDataToken
    {
        public double minEM { get; }
        public double maxEM { get; }

        public MassRngData(IFunctionNames fn, double minEM, double maxEM) : base(fn.MassRng)
        {            
            this.minEM = minEM;
            this.maxEM = maxEM;
        }        
    }
}
