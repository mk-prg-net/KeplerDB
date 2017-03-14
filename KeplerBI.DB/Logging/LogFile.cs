//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2016
//
//  Projekt.......: KeplerBI.DB
//  Name..........: LogFile.cs
//  Aufgabe/Fkt...: Log- Eintrag
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
using KeplerBI.Logging;

using S = System.ComponentModel.DataAnnotations;

namespace KeplerBI.DB.Logging
{
    [S.Schema.Table("Logs", Schema = "admin")]
    public class LogFile : KeplerBI.Logging.ILogFile
    {
        /// <summary>
        /// Datenbankschlüssel
        /// </summary>
        public int LogFileId { get; set; }

        public DateTime LogTime
        {
            get;
            set;
        }

        [S.StringLength(1000)]
        public string Message
        {
            get;
            set;
        }

        public LogTypes Type
        {
            get;
            set;
        }

        [S.StringLength(100)]
        public string User
        {
            get;
            set;
        }
    }
}
