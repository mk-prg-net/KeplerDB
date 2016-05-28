using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN.Arithmetik
{
    public abstract class NumBinOp : BasicEvaluator
    {
        public NumBinOp() : base(2) { }
        //protected void PopOperand(Stack<IToken> stack, out double op)
        //{
        //    if (stack.Peek().IsNummeric)
        //    {
        //        if (stack.Peek().IsInteger)
        //        {
        //            var token = stack.Pop() as IntToken;
        //            op = token.ValueAsInt;
        //        }
        //        else
        //        {
        //            var token = stack.Pop() as DoubleToken;
        //            op = token.ValueAsDouble;
        //        }
        //    }
        //    else
        //    {
        //        op = 0;
        //        _ex = new ArgumentException("NumBinOp benötigt nummerische Parameter");
        //    }
        //}

        //public bool Succesful
        //{
        //    get { return _Succesful; }
        //}
        //protected bool _Succesful;

        //public Exception EvalException
        //{
        //    get { return _ex; }
        //}
        //protected Exception _ex;

        //public void Eval(Stack<IToken> stack)
        //{
        //    if (stack.Count >= 2 && stack.Peek().IsNummeric)
        //    {
        //        double a = 0;
        //        PopOperand(stack, out a);

        //        double b = 0;
        //        PopOperand(stack, out b);

        //        stack.Push(new DoubleToken(Func(a, b)));
        //        _Succesful = true;
        //    }
        //    else
        //    {
        //        _Succesful = false;
        //        _ex = new ArgumentException("ADD benötigt midestens zwei nummerische Parameter");
        //    }
        //}

        protected abstract double Func(double a, double b);

        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            var a = PopNummeric(stack);
            var b = PopNummeric(stack);

            stack.Push(new DoubleToken(Func(a, b)));
        }
    }
}
