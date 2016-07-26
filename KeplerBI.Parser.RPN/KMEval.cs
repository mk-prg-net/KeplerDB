using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Rechnet  Stack:...[Abstand in Kilometer][KM] in Stack:...[Abstand in Meter] um
    /// </summary>
    public class KMEval : mko.RPN.BasicEvaluator
    {
        public KMEval() : base(1) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var val = PopNummeric(stack);

            stack.Push(new mko.RPN.DoubleToken(val.Item1 * 1000.0, val.Item2.CountOfEvaluatedTokens +1));
        }
    }
}
