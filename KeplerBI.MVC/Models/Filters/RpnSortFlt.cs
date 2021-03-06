﻿//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 12.4.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: RpnRngFlt.c
//  Aufgabe/Fkt...: Modell für Views von Sortier- Ausdrücke
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
using System.Web;

using mko.RPN;

namespace KeplerBI.MVC.Models.Filters
{
    public class RpnSortFlt : Rpn
    {
        public RpnSortFlt(string ControllerName, Parser.RPN.IFunctionNames fn, IToken[] tokens, IToken[] fSubtree, params string[] ParameterNames)
            : base(ControllerName, fn, tokens, fSubtree, ParameterNames)
        {
            var Key = ParameterSubTrees[0].Key;
            ParamTag = fn.IsSemanticDescriptor(Key) ? fn.ReduceSematicFunctionName(Key) : Key;

            var Parser = new mko.RPN.Parser(new KeplerBI.Parser.RPN.FnameEvalTab(fn).FuncEvaluators);

            Parser.Parse(fSubtree);
            mko.TraceHlp.ThrowExIfNot(Parser.Succsessful, Properties.Resources.PNParseFailed);
            mko.TraceHlp.ThrowArgExIfNot(Parser.Stack.Count == 1, Properties.Resources.PNParseFailed);

            var OrderByCfg = (KeplerBI.Parser.RPN.OrderByConfigDataToken)Parser.Stack.Peek();

            SortDescending = OrderByCfg.descending;
        }

        public string ParamTag { get; set; }
        public bool SortDescending { get; set; }
    }
}