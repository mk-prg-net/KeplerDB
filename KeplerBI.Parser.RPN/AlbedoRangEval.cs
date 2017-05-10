//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.5.2016
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: AlbedoRngEval.cs
//  Aufgabe/Fkt...: Filtern nach der HElligkeit- Evaluator
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

namespace KeplerBI.Parser.RPN
{

    /// <summary>
    /// Planets.FilterSortedSetBuilder.defAequatorialDiameterRange- Funktion evaluieren: wird an Parameter gebunden.
    /// </summary>
    public class AlbedoRngEval : mko.RPN.BasicEvaluator
    {
        public AlbedoRngEval(IFunctionNames fn) : base(2)
        {
            this.fn = fn;
        }

        IFunctionNames fn;
        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var min = PopNummeric(stack);
            var max = PopNummeric(stack);

            stack.Push(new AlbedoRng(fn, min.Item1, max.Item1));
        }
    }
}
