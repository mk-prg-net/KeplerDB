//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerBI.DB
//  Name..........: FSSBld.cs
//  Aufgabe/Fkt...: Definieren eienr gefilterten Menge von Logs
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
using mko.BI.Repositories.Interfaces;

namespace KeplerBI.DB.Logging.Repositories
{
    public class FSSBld : KeplerBI.Logging.Repositories.IFSSBld
    {
        IQueryable<LogFile> _Logs;

        List<mko.BI.Repositories.DefSortOrder<LogFile>> SortOrders = new List<mko.BI.Repositories.DefSortOrder<LogFile>>();

        public FSSBld(IQueryable<LogFile> Logs)
        {
            _Logs = Logs;
        }

        public void defLogTimeRange(DateTime begin, DateTime end)
        {
            _Logs = _Logs.Where(r => r.LogTime >= begin && r.LogTime <= end);
        }

        public void defLogType(LogTypes type)
        {
            _Logs = _Logs.Where(r => r.Type == type);
        }

        public IFilteredSortedSet<ILogFile> GetSet()
        {
            if (!SortOrders.Any())            
            {
                SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<LogFile, DateTime>(r => r.LogTime, false));
            }

            return new mko.BI.Repositories.FilteredSortedSet<LogFile>(_Logs, SortOrders);
        }

        public void OrderByLogTime(bool descending)
        {
            SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<LogFile, DateTime>(r => r.LogTime, descending));
        }

        public void OrderByLogType(bool descending)
        {
            SortOrders.Add(new mko.BI.Repositories.DefSortOrderCol<LogFile, LogTypes>(r => r.Type, descending));
        }
    }
}
