//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 23.11.2015
//
//  Projekt.......: Kepler.MVC
//  Name..........: HimmelskoerperPage.cs
//  Aufgabe/Fkt...: Modell für Übersicht aller Himmelskörper. Neben den Daten wird auch die 
//                  Seitennummer bereitgestellt
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


namespace Kepler.MVC.Models.TheUniverse
{
    public class HimmelskoerperPage : FilterPaging
    {
        /// <summary>
        /// 
        /// </summary>
        public IQueryable<DB.Kepler.EF60.Himmelskoerper> die_Himmelskoerper_auf_dieser_Seite { get; set; }

        public int TypFlt { get; set; }

    }
}