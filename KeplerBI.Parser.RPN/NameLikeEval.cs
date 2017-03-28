//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 14.3.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: NameLikeEval.ca
//  Aufgabe/Fkt...: Schränkt ein auf alle Datesätze, deren Namen den String enthält
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
    public class NameLikeEval: mko.RPN.BasicEvaluator
    {
        public NameLikeEval(): base(1) { }

        public override void ReadParametersAndEvaluate(Stack<IToken> stack)
        {
            if (mko.RPN.StringToken.Test(stack.Peek()))
            {
                stack.Push(new NameLikeData(((mko.RPN.StringToken)stack.Pop()).Value));
            } else
            {
                throw new Exception("NameLike muss als Parameter einen String haben");
            }
        }

    }
}
