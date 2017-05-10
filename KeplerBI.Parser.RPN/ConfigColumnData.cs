//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 3.4.2017
//
//  Projekt.......: KeplerBI.Parser.RPN
//  Name..........: ConfigColumnData.cs
//  Aufgabe/Fkt...: Definiert die Spalte, für die Filter, Sortier- und Select Einstellungen
//                  nachträglich bearbeitet werden sollen.
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
    public class ConfigColumnData : ConfigDataToken
    { 
        public ConfigColumnData(IFunctionNames fn, string ColumnName) : base(fn.ConfigColumn)
        {
            this.fn = fn;
            this.ColumnName = ColumnName;
            HasMeasureInfo = false;
        }

        IFunctionNames fn;

        public ConfigColumnData(IFunctionNames fn, string ColumnName, string MeasureInfo) : base(fn.ConfigColumn)
        {
            this.fn = fn;
            this.ColumnName = ColumnName;
            this.HasMeasureInfo = true;
            this.MeasureInfo = MeasureInfo;

        }

        public string ColumnName { get; }

        /// <summary>
        /// Wenn true, dann gibt es zusätzlich zum Spaltennamen eine Info zu der Maßeinheit, in welcher 
        /// die Werte in der Spalte notiert sind
        /// </summary>
        public bool HasMeasureInfo { get; }

        /// <summary>
        /// Maßeinheit, in der die Messwerte dargestellt werden
        /// </summary>
        public string MeasureInfo { get; }
    }
}
