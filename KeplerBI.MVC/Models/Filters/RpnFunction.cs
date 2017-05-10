//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 29.3.2017
//
//  Projekt.......: KeplerDB.MVC
//  Name..........: DiameterRng
//  Aufgabe/Fkt...: View model von Funktionen mit komplexen Parametern in RPN
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
    public class RpnFunction
    {

        public RpnFunction(mko.RPN.IToken[] Subtree, params string[] ParameterNames)
        {
            mko.TraceHlp.ThrowArgExIfNot(Subtree.Last().IsFunctionName, Properties.Resources.Models_Filters_ConfigData_rpn_function_functionname_token_missing);

            this.ParameterNames = ParameterNames;
            ParameterSubTrees = new Dictionary<string, IToken[]>(ParameterNames.Length);
            ParameterCount = ParameterNames.Length;


            // Bestimmen der Parameter- Subtrees            
            //mko.TraceHlp.ThrowArgExIf(!revSubtree.Any() && ParameterNames.Length > 0, string.Format(Properties.Resources.Models_Filters_ConfigData_rpn_function_invalid_paramlist, Subtree.Last().Value));

            int ixMain = Subtree.Length - 1;
            Name = Subtree[ixMain].Value;
            int i = 1;
            foreach (var p in ParameterNames)
            {
                var ixPi = Subtree.IndexOfFunctionParameter(ixMain, i);
                ParameterSubTrees[p] = Subtree.GetSubtree(ixPi.IX);
                i++;
            }
        }   
        
        /// <summary>
        /// Name der Funktion, die durch den Subtree dargestellt wird
        /// </summary>
        public string Name { get; }     

        /// <summary>
        /// Liste der Parameternamen
        /// </summary>
        public IList<string> ParameterNames { get; }

        /// <summary>
        /// Anzahl der Parameter
        /// </summary>
        public int ParameterCount { get; }

        /// <summary>
        /// Subtree zu jedem Parameter
        /// </summary>
        public Dictionary<string, mko.RPN.IToken[]> ParameterSubTrees { get; }


    }
}