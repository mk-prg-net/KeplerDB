using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class SemiMajorAxisLengthRngConfigCmd : ConfigCmdToken
    {

        public double Min
        {
            get
            {
                return min;
            }
        }
        double min;


        public double Max
        {
            get
            {
                return max;
            }
        }
        double max;

        public SemiMajorAxisLengthRngConfigCmd(double min, double max,  int CountOfEvaluatedTokens) : base(CountOfEvaluatedTokens)        
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
            var minAU = mko.Newton.Length.AU(mko.Newton.Length.Kilometer(min)).Vector[0];
            var maxAU = mko.Newton.Length.AU(mko.Newton.Length.Kilometer(max)).Vector[0];

            return minAU.ToString("N0") + " " + Tokenizer.AU + " " + maxAU.ToString("N0") + " " + Tokenizer.AU + " " + Tokenizer.SemiMajorAxisLengthRng;

        }
    }
}
