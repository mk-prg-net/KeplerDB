using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class SemiMajorAxisLengthRngData : ConfigDataToken
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

        public SemiMajorAxisLengthRngData(double min, double max) : base(Tokens.SemiMajorAxisLengthRng)        
        {
            this.min = min;
            this.max = max;
        }   
    }
}
