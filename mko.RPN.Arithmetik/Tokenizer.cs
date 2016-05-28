using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN.Arithmetik
{
    public class Tokenizer : mko.RPN.BasicTokenizer
    {
        public Tokenizer(System.IO.StreamReader reader) : base(reader) { }

        public Tokenizer(string term) : base(term) { }

        protected override bool TryParseUserdefinedType(string rawToken, out IToken token)
        {            
            if (rawToken == "ADD")
            {
                token = new FunctionNameToken("ADD");
                return true;
            }
            else if (rawToken == "SUB")
            {
                token = new FunctionNameToken("SUB");
                return true;
            }
            else if (rawToken == "MUL")
            {
                token = new FunctionNameToken("MUL");
                return true;
            }
            else if (rawToken == "DIV")
            {
                token = new FunctionNameToken("DIV");
                return true;
            }
            else
            {
                token = null;
                return false;
            }
        }
    }
}
