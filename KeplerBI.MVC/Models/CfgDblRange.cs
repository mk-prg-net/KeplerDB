//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 3.4.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: CfgDiameter.cs
//  Aufgabe/Fkt...: Viewmodell zum, configurieren der Diameter- Spalte
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
    public class CfgDblRange : Cfg 
    {
        public CfgDblRange(string colName, bool viewCol, string rpnOri, string Controller, string Action, Cfg.SortDirection sort, mko.BI.Bo.Interval<double> range,  mko.BI.Bo.Interval<double> subRange)
            : base(colName, viewCol, sort, rpnOri, Controller, Action)
        {
            this.Range = range;
            this.SubRange = subRange;
        }

        /// <summary>
        /// Kompleter Wertebereich, dargestellt in der Basiseinheit
        /// </summary>
        public mko.BI.Bo.Interval<double> Range { get; }

        /// <summary>
        /// Bereich, auf den die Datensätze eingeschränkt werden, dargestellt in der Basiseinheit.
        /// </summary>
        public mko.BI.Bo.Interval<double> SubRange { get ;}

        /// <summary>
        /// Filterung ist aktiv, wenn Subrange und Range ungleich sind und der Subrange stärker Einschränkt als Ranger
        /// </summary>
        public bool IsFilterActive
        {
            get
            {
                return !mko.BI.Bo.Interval.Equals(SubRange, Range) && mko.BI.Bo.Interval.Equals(Range.Intersect(SubRange), SubRange);
            }
        }
    }
}