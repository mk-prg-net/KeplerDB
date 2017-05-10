//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 3.4.2016
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: ConfigColumnEval.cs
//  Aufgabe/Fkt...: Evaluiert die Cfg- Funktion, welche eine Spalte für die 
//                  Konfiguration von Filter- und Sortiereinstellungen auswählt
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
    public class ConfigColumnEval : mko.RPN.BasicEvaluator
    {
        public ConfigColumnEval(IFunctionNames fn) : base(1)
        {
            this.fn = fn;
        }

        IFunctionNames fn;

        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            var arg = stack.Peek();
            mko.TraceHlp.ThrowArgExIfNot(mko.RPN.StringToken.Test(stack.Peek()), Properties.Resources.ConfigColEval_ArgEx_NoColname);

            var p2 = (StringToken)stack.Pop();

            if (StringToken.Test(stack.Peek()))
            {
                var p1 = (StringToken)stack.Pop();
                stack.Push(new ConfigColumnData(fn, p1.Value, p2.Value));
            } else
            {
                stack.Push(new ConfigColumnData(fn, p2.Value));
            }            
        }
    }
}
