
//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 24.7.2017
//
//  Projekt.......: Projektkontext
//  Name..........: Dateiname
//  Aufgabe/Fkt...: Kurzbeschreibung
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

namespace KeplerBI.MVC.Models.rpn_help
{
    public class AstroComposers
    {
        public AstroComposers(string SupportedController, string Action, string pn)
        {
            this.SupportedController = SupportedController;
            this.Action = Action;
            this.pn = pn;
            composer = new Parser.RPN.Composer(new KeplerBI.Parser.RPN.BasicFunctionNames());
        }

        public string SupportedController { get; }
        public string Action { get; }
        public string pn { get; }

        public KeplerBI.Parser.RPN.Composer composer
        {
            get;
        }
    }
}