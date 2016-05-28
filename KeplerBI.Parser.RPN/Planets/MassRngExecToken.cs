using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    /// <summary>
    /// Evaluierte Planets.FilterSortedSetBuilder.defMassRange- Funktion ausführen
    /// </summary>
    public class MassRngExecToken : ExecToken
    {
        double min;
        double max;

        public MassRngExecToken(double min, double max)
        {
            this.min = min;
            this.max = max;
        }    

        /// <summary>
        /// Führt die durch 
        /// </summary>
        /// <param name="bld"></param>
        public void Exec(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.defMassRange(mko.Newton.Mass.Kilogram(min), mko.Newton.Mass.Kilogram(max));
        }
    }
}
