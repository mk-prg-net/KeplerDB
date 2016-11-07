using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class SemiMajorAxisLengthRngEval : mko.RPN.BasicEvaluator 
    {
        public SemiMajorAxisLengthRngEval() : base(2) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            // Einlesen des Zulässigen Bereiches für Bahnradien. Einheit ist immer das Meter.
            var max = PopNummeric(stack);
            var min = PopNummeric(stack);

            stack.Push(new SemiMajorAxisLengthRngData(min.Item1, max.Item1));
        }
    }
}
