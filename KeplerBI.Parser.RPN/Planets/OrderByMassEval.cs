using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public class OrderByMassEval : BasicOrderByEval
    {
        protected override void BindArgOrderBy(Stack<mko.RPN.IToken> stack, bool descending)
        {
            stack.Push(new OrderByMassConfigCmd(descending));
        }
    }
}
