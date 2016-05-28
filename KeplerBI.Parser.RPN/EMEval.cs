using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class EMEval : mko.RPN.IEval
    {       
        public void Eval(Stack<mko.RPN.IToken> stack)
        {

            if (stack.Count >= 1)
            {
                if (stack.Peek().IsNummeric)
                {
                    double val = mko.RPN.BasicEvaluator.PopNummeric(stack);
                    stack.Push(new mko.RPN.DoubleToken(mko.Newton.Mass.Kilogram(mko.Newton.Mass.EarthMasses(val)).Value));
                    _successful = true;
                }
                else
                {
                    _successful = false;
                    _ex = new ArgumentException("EM (EarthMasses) Funktion benötigt einen nummerischen Parameter");
                }
            }
            
        }

        public bool Succesful
        {
            get { return _successful; }
        }
        bool _successful;

        public Exception EvalException
        {
            get { return _ex; }
        }
        Exception _ex;
    }
}
