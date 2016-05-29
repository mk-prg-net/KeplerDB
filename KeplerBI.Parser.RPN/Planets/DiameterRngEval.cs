//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 27.5.2016
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: MassRngEval.cs
//  Aufgabe/Fkt...: Planets.FilterSortedSetBuilder.defAequatorialDiameterRange- Funktion evaluieren:
//                  <=> wird an Parameter gebunden.
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

namespace KeplerBI.Parser.RPN.Planets
{

    /// <summary>
    /// Planets.FilterSortedSetBuilder.defAequatorialDiameterRange- Funktion evaluieren: wird an Parameter gebunden.
    /// </summary>
    public class DiameterRngEval : mko.RPN.BasicEvaluator
    {
        public DiameterRngEval() : base(2) { }

        public override void ReadParametersAndEvaluate(Stack<mko.RPN.IToken> stack)
        {
            var max = PopNummeric(stack);
            var min = PopNummeric(stack);

            stack.Push(new DiameterRngConfigCmd(min, max));
        }
    }
}
