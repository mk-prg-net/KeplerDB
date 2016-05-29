using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Rechnet  Stack:...[Masse in Erdmassen][SM] in Stack:...[Masse in Kilogramm] um
    /// </summary>
    public class SMEval : mko.RPN.BasicEvaluator
    {
        public SMEval() : base(1) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var val = PopNummeric(stack);

            stack.Push(new mko.RPN.DoubleToken(mko.Newton.Mass.Kilogram(val * mko.Newton.Mass.MassOfSun.Value).Value));
        }
    }
}
