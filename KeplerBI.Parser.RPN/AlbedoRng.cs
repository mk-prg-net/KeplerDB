using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class AlbedoRng : ConfigDataToken
    {
        public double min;
        public double max;

        public AlbedoRng(IFunctionNames fn, double min, double max)
            : base(fn.AlbedoRng)
        {
            this.min = min;
            this.max = max;
        }

    }
}
