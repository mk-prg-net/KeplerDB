using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mko.RPN;

namespace KeplerBI.Parser.RPN
{
    class Tokenizer: mko.RPN.BasicTokenizer
    {
        public Tokenizer(System.IO.StreamReader reader) : base(reader) { }

        public Tokenizer(string term) : base(term) { }

        protected override bool TryParseUserdefinedType(string rawToken, out IToken token)
        {

            switch (rawToken)
            {
                case "EM":
                case "MassRng":
                case "AU":
                case "DiameterRng":
                    token = new FunctionNameToken(rawToken);
                    return true;                    
                default:
                    token = null;
                    return false;
            }
        }
    }
}
