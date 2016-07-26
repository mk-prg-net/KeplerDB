using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class StringToken : NoFunctionToken
    {
        public StringToken(string Value, int CountOfEvaluatedTokens = 1)
            : base(CountOfEvaluatedTokens)
        {
            _Value = Value;
        }        

        
        string _Value;

        protected override string ValueToString
        {
            get { return _Value; }
        }

        public override bool IsInteger
        {
            get { return false; }
        }

        public override bool IsBoolean
        {
            get { return false; }
        }

        public override bool IsNummeric
        {
            get { return false; }
        }
    }
}
