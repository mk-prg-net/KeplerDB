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

        IFunctionNames fn;

        public DiameterRngData(IFunctionNames fn, double min, double max)
            : base(fn.DiameterRng)
        {
            this.fn = fn;
            this.Min = min;
            this.Max = max;
        }    

    }
}
