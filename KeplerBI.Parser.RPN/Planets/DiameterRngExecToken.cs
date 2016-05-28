using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class DiameterRngExecToken : ExecToken
    {
        double min;
        double max;

        public DiameterRngExecToken(double min, double max)
        {
            this.min = min;
            this.max = max;
        }    

        public void Exec(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.defAequatorialDiameterRange(mko.Newton.Length.Meter(min), mko.Newton.Length.Meter(max));
        }

    }
}
