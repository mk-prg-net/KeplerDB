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
    public class MassRngConfigCmd : ConfigCmdToken
    {
        double minEM;
        double maxEM;

        public MassRngConfigCmd(double minEM, double maxEM)
        {
            this.minEM = minEM;
            this.maxEM = maxEM;
        }

        /// <summary>
        /// Führt die durch 
        /// </summary>
        /// <param name="bld"></param>
        public override void ConfigBld(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.defMassRange(mko.Newton.Mass.EarthMasses(minEM), mko.Newton.Mass.EarthMasses(maxEM));
        }

        public override string ToRPNString()
        {

            return minEM.ToString("N4") + " " + Tokenizer.EM + " " + maxEM.ToString("N4") + " " + Tokenizer.EM + " " + Tokenizer.MassRng;
        }
    }
}
