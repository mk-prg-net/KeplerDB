//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 8.3.2017
//
//  Projekt.......: KeplerDB
//  Name..........: Logs.cs
//  Aufgabe/Fkt...: Liste aller Logeinträge
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
using KeplerBI.Logging.Repositories;


namespace KeplerBI.DB.Logging.Repositories
{
    public class Logs : KeplerBI.Logging.Repositories.ILogFileCo
    {
        KeplerDBContext _ctx;

        public Logs(KeplerDBContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(LogTypes type, string message, string user = null)
        {
            try
            {
                var log = _ctx.Logs.Create();
                log.LogTime = DateTime.Now;
                log.Message = message;
                log.Type = type;
                log.User = user;

                _ctx.Logs.Add(log);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg(this, "Create"), ex);
            }
        }

        public IFSSBld CreateFSSBld()
        {
            throw new NotImplementedException();
        }
    }
}
