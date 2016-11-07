using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderByMassEval : BasicOrderByEval
    {
        protected override void BindArgOrderBy(Stack<mko.RPN.IToken> stack, bool descending, int CountOfEvaluatedTokens)
        {
            stack.Push(new OrderByMassData(descending));
        }
    }
}
