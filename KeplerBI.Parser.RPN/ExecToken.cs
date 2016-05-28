using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class ExecToken : mko.RPN.IToken
    {
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
            get { return false; }
        }

        public string Value
        {
            get { return GetType().Name; }
        }
    }
}
