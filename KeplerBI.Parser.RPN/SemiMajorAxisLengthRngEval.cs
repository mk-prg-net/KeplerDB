using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class SemiMajorAxisLengthRngEval : mko.RPN.BasicEvaluator 
    {
        public SemiMajorAxisLengthRngEval(IFunctionNames fn) : base(2)
        {
            this.fn = fn;
        }

        IFunctionNames fn;
        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            // Einlesen des Zulässigen Bereiches für Bahnradien. Einheit ist immer das Meter.
            var min = PopNummeric(stack);
            var max = PopNummeric(stack);

            stack.Push(new SemiMajorAxisLengthRngData(fn, min.Item1, max.Item1));
        }
    }
}
