using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.RPN.Arithmetik
{
    public class Add : NumBinOp
    {

        protected override double Func(double a, double b)
        {
            return a + b;
        }
    }

    public class Sub : NumBinOp
    {

        protected override double Func(double a, double b)
        {
            // Reihenfolge der Operanden vertauscht, da RPN die Operanden "rückwärts" einliest
            return b - a;
        }
    }

    public class Mul : NumBinOp
    {

        protected override double Func(double a, double b)
        {
            return a * b;
        }
    }

    public class Div : NumBinOp
    {

        protected override double Func(double a, double b)
        {
            // Reihenfolge der Operanden vertauscht, da RPN die Operanden "rückwärts" einliest
            return b / a;
        }
    }
}
