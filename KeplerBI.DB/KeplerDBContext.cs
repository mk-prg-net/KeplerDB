//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 
//
//  Projekt.......: Projektkontext
//  Name..........: Dateiname
//  Aufgabe/Fkt...: Kurzbeschreibung
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

using System.Data.Entity;

using NCB = KeplerBI.NaturalCelesticalBodies;

using S = System.ComponentModel.DataAnnotations;

namespace KeplerBI.DB
{
    public partial class KeplerDBContext : DbContext
    {
        public KeplerDBContext() : base("name=KeplerBiContext") { }

        public virtual DbSet<CelesticalBodyTypeDescriptor> CelesticalBodyTypes { get; set; }

        public virtual DbSet<CelestialBodyBase> CelesticalBodies { get; set; }

        public virtual DbSet<Orbit> Orbits { get; set; }

        public virtual DbSet<CelesticalBodySystem> CelesticalBodySystems { get; set; }
        
        public virtual DbSet<Logging.LogFile> Logs { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        /// <summary>
        /// Liste der Konfigurationsstrings
        /// </summary>
        public virtual DbSet<Config.ConfigString> ConfigStrings { get; set; }
       
    }
}
