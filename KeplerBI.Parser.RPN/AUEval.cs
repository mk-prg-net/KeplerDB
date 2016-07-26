
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Rechnet  Stack:...[Abstand in astronomischen Einheiten][AU] in Stack:...[Abstand in Meter] um
    /// </summary>
    public class AUEval: mko.RPN.BasicEvaluator 
    {
        public AUEval() : base(1) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var val = PopNummeric(stack);

            stack.Push(new mko.RPN.DoubleToken(mko.Newton.Length.Meter(mko.Newton.Length.AU(val.Item1)).Vector[0], val.Item2.CountOfEvaluatedTokens + 1));
        }
    }
}
