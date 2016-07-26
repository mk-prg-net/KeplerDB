using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Rechnet  Stack:...[Masse in Erdmassen][EM] in Stack:...[Masse in Kilogramm] um
    /// </summary>
    public class EMEval : mko.RPN.BasicEvaluator
    {
        public EMEval() : base(1) { }


        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var val = PopNummeric(stack);

            stack.Push(new mko.RPN.DoubleToken(mko.Newton.Mass.Kilogram(mko.Newton.Mass.EarthMasses(val.Item1)).Value, val.Item2.CountOfEvaluatedTokens + 1));

        }
    }
}
