﻿//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 10.3.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: OrderByDiameterEval.cs
//  Aufgabe/Fkt...: Evaluator für Sortierung nach Durchmesser
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
    public class OrderByDiameterEval : BasicOrderByEval
    {
        public OrderByDiameterEval(IFunctionNames fn) : base(fn) { }

        protected override void BindArgOrderBy(IFunctionNames fn, Stack<mko.RPN.IToken> stack, bool descending, int CountOfEvaluatedTokens)
        {
            stack.Push(new OrderByDiameter(fn, descending));
        }
    }
}
