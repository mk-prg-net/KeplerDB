using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class DiameterRngData : ConfigDataToken
    {
        public double min;
        public double max;

        public DiameterRngData(double min, double max)
            : base(Tokenizer.DiameterRng)
        {
            this.min = min;
            this.max = max;
        }    

    }
}
