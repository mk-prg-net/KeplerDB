using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class OrderByMassConfigCmd : ConfigCmdToken
    {
        bool descending;

        public OrderByMassConfigCmd(bool descending)
        {
            this.descending = descending;
        }

        public override void ConfigBld(NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            bld.OrderByMass(descending);
        }

        public override string ToRPNString()
        {
            return (descending ? "desc" : "asc") + " " + Tokenizer.OrderByMass;
        }
    }
}
