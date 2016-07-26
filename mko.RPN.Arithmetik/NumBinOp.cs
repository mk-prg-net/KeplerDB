using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN.Arithmetik
{
    public abstract class NumBinOp : BasicEvaluator
    {
        BufferedTokenizer TokenBuffer;

        public NumBinOp(BufferedTokenizer TokenBuffer) : base(2) 
        {
            this.TokenBuffer = TokenBuffer;
        }

        protected abstract double Func(double a, double b);

        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            var a = PopNummeric(stack);
            var b = PopNummeric(stack);

            var res = new DoubleToken(Func(a.Item1, b.Item1), a.Item2.CountOfEvaluatedTokens + b.Item2.CountOfEvaluatedTokens + 1);
            stack.Push(res);

            // Nur Parameter einer Funktion aufzeichnen, die nicht durch Evaluierung entstanden sind
            if(b.Item2.CountOfEvaluatedTokens == 1) TokenBuffer.Add(b.Item2);
            if(a.Item2.CountOfEvaluatedTokens == 1) TokenBuffer.Add(a.Item2);
            TokenBuffer.Add(new FunctionNameToken(this.GetType().Name, res.CountOfEvaluatedTokens));
        }
    }
}
