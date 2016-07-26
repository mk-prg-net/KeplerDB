using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public abstract class BasicOrderByEval : mko.RPN.BasicEvaluator
    {
        public BasicOrderByEval() : base(1) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var arg = stack.Peek();
            if (!arg.IsNummeric && !arg.IsFunctionName && !arg.IsBoolean && (arg.Value == "asc" || arg.Value == "desc"))
            {
                arg = stack.Pop();
                bool descending = arg.Value == "desc";

                BindArgOrderBy(stack, descending, arg.CountOfEvaluatedTokens);
            }
            else
            {
                throw new ArgumentException(mko.TraceHlp.FormatErrMsg(this, "ReadParametersAndEvaluate", arg.Value));
            }
        }
        protected abstract void BindArgOrderBy(Stack<mko.RPN.IToken> stack, bool descending, int CountOfEvaluatedTokens);
    }
}
