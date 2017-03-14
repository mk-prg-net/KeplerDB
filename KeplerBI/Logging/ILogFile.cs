//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI
//  Name..........: ILogfile.cs
//  Aufgabe/Fkt...: Liste zur zentralen Erfassung von Meldungen 
//                  während des Betriebes.
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

namespace KeplerBI.Logging
{

    public enum LogTypes
    {
        Info,
        Warning,
        Error
    }


    public interface ILogFile
    {
        /// <summary>
        /// Zeitpunkt, zu dem der Eintrag erzeugt wurde
        /// </summary>
        DateTime LogTime { get; set; }

        /// <summary>
        /// Typ des Eintrages
        /// </summary>
        LogTypes Type { get; set; }

        /// <summary>
        /// Datenbankbenutzer, durch den der Eintrag verursacht wurde
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// Beschreibung der Umstände
        /// </summary>
        string Message { get; set; }

    }
}
