//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 7.6.2016
//
//  Projekt.......: KeplerBI.DB
//  Name..........: AstroCatalogConfig.cs
//  Aufgabe/Fkt...: Implementierung der Konfigurationsdatenverwaltung
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

namespace KeplerBI.DB
{
    public class AstroCatalogConfig : IAstroCatalogConfig
    {
        KeplerDBContext ctx;        

        public AstroCatalogConfig(KeplerDBContext ctx)
        {
            this.ctx = ctx;
            
        }

        public void defLocationOfPics(string path)
        {
            try
            {
                var cfg = ctx.ConfigStrings.Find(KeplerBI.Config.Parameters.defLocationOfPics);
                if (cfg != null)
                {
                    cfg.Value = path;
                }
                else
                {
                    cfg = ctx.ConfigStrings.Create();
                    cfg.Name = KeplerBI.Config.Parameters.defLocationOfPics;
                    cfg.Value = path;
                    ctx.ConfigStrings.Add(cfg);
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(mko.TraceHlp.FormatErrMsg(this, "defLocationOfPics"), ex);
            }
        }

        public KeplerBI.Config.Repositories.IConfigStringsCo ConfigStrings
        {
            get {
                if (_ConfigStringsCo == null)
                {
                    _ConfigStringsCo = new Config.Repositories.ConfigStringsCo(ctx);
                }
                return _ConfigStringsCo;
            }
        }
        Config.Repositories.ConfigStringsCo _ConfigStringsCo;
    }
}
