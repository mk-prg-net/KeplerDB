//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.3.2017
//
//  Projekt.......: KEplerBI.Parser.RPN
//  Name..........: TakeEval.cs
//  Aufgabe/Fkt...: Evaluiert Take
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mko.RPN;

namespace KeplerBI.Parser.RPN
{
    public class TakeEval : mko.RPN.BasicEvaluator
    {
        public TakeEval(IFunctionNames fn) : base(1)
        {
            this.fn = fn;
        }

        IFunctionNames fn;
        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            var count = PopNummeric(stack);
            stack.Push(new TakeData(fn, (int)count.Item1));
        }

    }
}
