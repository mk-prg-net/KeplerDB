//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: SemFuncEval.cs
//  Aufgabe/Fkt...: Evaluator für semantische Descriptoren.
//                  Ein Semantischer Deskriptor weist seimen Parameter eine
//                  BEdeutung zu. 
//                  Konsequent macht die Evaluierungsfunktion nichts.
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
    public class SemFuncEval : mko.RPN.BasicEvaluator
    {
        public SemFuncEval() : base(1) { }

        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            // Einfach nichts tun. Funktion hat nur rein informelle Bedeutung
            // (weist dem Parameter eine BEdeutung zu)
        }
    }
}
