//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 4.4.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: CfgVelocityRng.cs
//  Aufgabe/Fkt...: Model für Konfiguration von Geschwindigkeitsbereichen
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

namespace KeplerBI.MVC.Models
{
    /// <summary>
    /// Model für Konfiguration von Geschwindigkeitsbereichen
    /// </summary>
    public class CfgVelocityRng : CfgDblRange
    {
        public CfgVelocityRng(string colName, bool viewCol, string rpnOri, string Controller, string Action, Cfg.SortDirection sort, mko.BI.Bo.Interval<double> range, mko.BI.Bo.Interval<double> subRange)
            : base(colName, viewCol, rpnOri, Controller, Action, sort, range, subRange)
        {
        }

        /// <summary>
        /// Liste der Maßeinheiten
        /// </summary>
        public IEnumerable<string> Units
        {
            get
            {
                yield return "m_per_s";
                yield return "km_per_h";
                yield return "km_per_s";                
            }
        }

        public string Unit_of_begin { get; }

        public string Unit_of_end { get; }

    }
}