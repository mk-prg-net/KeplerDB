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

        public AlbedoRng(double min, double max)
            : base(Tokenizer.AlbedoRng)
        {
            this.min = min;
            this.max = max;
        }

    }
}
