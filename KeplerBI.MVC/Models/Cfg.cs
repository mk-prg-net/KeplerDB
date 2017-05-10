//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 3.4.2017
//
//  Projekt.......: Kepler.BI.MVC
//  Name..........: Cfg.cs
//  Aufgabe/Fkt...: Basisklasse aller Modelle für Dialoge zur 
//                  Konfiguration von Filtern und Sortierungen
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
    public class Cfg
    {
        public enum SortDirection
        {
            /// <summary>
            /// Keine Sortierung
            /// </summary>
            none,

            /// <summary>
            /// aufsteigend
            /// </summary>
            up,

            /// <summary>
            /// absteigend
            /// </summary>
            down
        }

        public Cfg(string ColName, bool viewCol, SortDirection sort, string rpnOri, string Controller, string Action)
        {
            this.ColName = ColName;
            this.viewCol = viewCol;            
            this.Sort = sort;
            this.RpnOri = rpnOri;
            this.ControllerName = Controller;
            this.ActionName = Action;

        }

        /// <summary>
        /// Name des Controllers, der die neu eingestellten Filter verarbeiten soll.
        /// Dient zum Konfigurieren des Submits in der CfgView
        /// </summary>
        public string ControllerName { get; }

        /// <summary>
        /// Name des Action, der die neu eingestellten Filter verarbeiten soll.
        /// Dient zum Konfigurieren des Submits in der CfgView
        /// </summary>
        public string ActionName { get; }


        /// <summary>
        /// Name der Spalte, die gefiltert oder sortiert werden soll
        /// </summary>
        public string ColName { get; }  


        /// <summary>
        /// Soll die Spalte angezeigt werden oder nicht
        /// </summary>
        public bool viewCol { get; }

        public SortDirection Sort { get; }

        /// <summary>
        /// Der originale RPN- String
        /// </summary>
        public string RpnOri { get; }


    }
}