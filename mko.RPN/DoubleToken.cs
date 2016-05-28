using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class DoubleToken : IToken
    {
        public DoubleToken(double Value)
        {
            _Value = Value;
        }

        public bool IsFunctionName
        {
            get { return false; }
        }

        public bool IsInteger
        {
            get { return false; }
        }

        public bool IsBoolean
        {
            get { return false; }
        }

        public bool IsNummeric
        {
            get { return true; }
        }

        public string Value
        {
            get { return _Value.ToString(); }
        }

        double _Value;

        public double ValueAsDouble
        {
            get
            {
                return _Value;
            }
        }

    }
}
