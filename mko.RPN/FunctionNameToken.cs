using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class FunctionNameToken : IToken
    {
        public FunctionNameToken(string functionName)
        {
            FunctionName = functionName;
        }

        public bool IsFunctionName
        {
            get { return true; }
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
            get { return FunctionName; }
        }
        string FunctionName;
    }
}
