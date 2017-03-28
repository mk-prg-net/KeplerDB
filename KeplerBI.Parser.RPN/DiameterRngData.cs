using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class DiameterRngData : ConfigDataToken
    {
        public double Min { get; }
        public double Max { get; }

        public DiameterRngData(double min, double max)
            : base(Tokens.DiameterRng)
        {
            this.Min = min;
            this.Max = max;
        }    

    }
}
