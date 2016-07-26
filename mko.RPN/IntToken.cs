using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN
{
    public class IntToken : NoFunctionToken
    {
        public IntToken(int Value, int CountOfEvaluatedTokens = 1)
            : base(CountOfEvaluatedTokens)
        {
            _Value = Value;            
        }

        int _Value;

        public int ValueAsInt
        {
            get
            {
                return _Value;
            }
        }

        protected override string ValueToString
        {
            get { return _Value.ToString(); }
        }

        public override bool IsInteger
        {
            get { return true; }
        }

        public override bool IsBoolean
        {
            get { return false; }
        }

        public override bool IsNummeric
        {
            get { return true; }
        }
    }
}
