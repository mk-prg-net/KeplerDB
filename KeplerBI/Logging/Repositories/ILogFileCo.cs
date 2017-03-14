//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI
//  Name..........: ILogFileCo.cs
//  Aufgabe/Fkt...: Repository für alle Log- Einträge <=> Logbuch
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
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Logging.Repositories
{
    public interface ILogFileCo
    {
        /// <summary>
        /// Erzeugt einen neuen Logbucheintrag
        /// </summary>
        /// <param name="type"></param>
        /// <param name="user"></param>
        /// <param name="message"></param>
        void Create(LogTypes type, string message, string user = null);

        /// <summary>
        /// Liefert einen FilteredSortedSet Builder, über den die Filterausdrücke eingestellt werden können
        /// </summary>
        /// <returns></returns>
        IFSSBld CreateFSSBld();

    }
}
