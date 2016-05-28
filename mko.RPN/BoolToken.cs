using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class BoolToken : IToken
    {
        public BoolToken(bool Value)
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
            get { return true; }
        }

        public bool IsNummeric
        {
            get { return false; }
        }

        public string Value
        {
            get { return _Value.ToString(); }
        }

        bool _Value;

        public bool ValueAsBool
        {
            get
            {
                return _Value;
            }
        }

    }
}
