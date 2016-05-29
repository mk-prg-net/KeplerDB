using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class SemiMajorAxisLengthRngConfigCmd : ConfigCmdToken
    {

        double min;
        double max;

        public SemiMajorAxisLengthRngConfigCmd(double min, double max)
        {
            this.min = min;
            this.max = max;
        }   

        public override void ConfigBld(NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.defSemiMajorAxisLengthRange(mko.Newton.Length.Meter(min), mko.Newton.Length.Meter(max));
        }

        public override string ToRPNString()
        {
            var minKm = min / 1000.0;
            var maxKm = max / 1000.0;

            return minKm.ToString("N0") + " " + Tokenizer.KM + maxKm.ToString("N0") + " " + Tokenizer.KM + " " + Tokenizer.SemiMajorAxisLengthRng;

        }
    }
}
