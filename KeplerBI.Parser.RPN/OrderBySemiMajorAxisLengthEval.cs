using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderBySemiMajorAxisLengthEval : BasicOrderByEval
    {
        public OrderBySemiMajorAxisLengthEval(IFunctionNames fn) : base(fn) { }

        protected override void BindArgOrderBy(IFunctionNames fn, Stack<mko.RPN.IToken> stack, bool descending, int CountOfEvaluatedTokens)
        {
            stack.Push(new OrderBySemiMajorAxisLengthData(fn, descending));
        }
    }
}
