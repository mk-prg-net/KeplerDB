using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class OrderBySemiMajorAxisLengthConfigCmd: ConfigCmdToken
    {
        bool descending;

        public OrderBySemiMajorAxisLengthConfigCmd(bool descending,  int CountOfEvaluatedTokens) : base(CountOfEvaluatedTokens)        
        {
            this.descending = descending;
        }

        public override void ConfigBld(NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.OrderBySemiMajorAxisLength(descending);
        }

        public override string ToRPNString()
        {
            return (descending ? "desc" : "asc") + " " + Tokenizer.OrderBySemiMajorAxisLength;
        }
    }
}
