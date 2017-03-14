//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI
//  Name..........: IFSSBld.cs
//  Aufgabe/Fkt...: Erzeugt einen Filtered Sorted Set Builder für 
//                  die Menge der Logbucheinträge
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

namespace KeplerBI.Logging.Repositories
{
    public interface IFSSBld : mko.BI.Repositories.Interfaces.IFilteredSortedSetBuilder<ILogFile>
    {
        /// <summary>
        /// Sortieren nach dem Zeitstempeln der Logbucheinträge
        /// </summary>
        /// <param name="descending"></param>
        void OrderByLogTime(bool descending);

        /// <summary>
        /// Sortieren nach dem Typ der Logmeldungen
        /// </summary>
        /// <param name="descending"></param>
        void OrderByLogType(bool descending);

        /// <summary>
        /// Einschränken auf alle Meldungen innerhalb eines Zeitraumes
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        void defLogTimeRange(DateTime begin, DateTime end);

        /// <summary>
        /// Einschränken auf alle Meldungen eines bestimmten Typs
        /// </summary>
        /// <param name="type"></param>
        void defLogType(LogTypes type);
    }
}
