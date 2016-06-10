using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using NCB = KeplerBI.NaturalCelesticalBodies;


namespace KeplerBI.DB
{
    public partial class KeplerDBContext : DbContext
    {
        public KeplerDBContext() : base("name=KeplerBiContext") { }

        public virtual DbSet<CelesticalBodyTypeDescriptor> CelesticalBodyTypes { get; set; }

        public virtual DbSet<CelestialBodyBase> CelesticalBodies { get; set; }

        public virtual DbSet<Orbit> Orbits { get; set; }

        public virtual DbSet<CelesticalBodySystem> CelesticalBodySystems { get; set; }


        /// <summary>
        /// Liste der Konfigurationsstrings
        /// </summary>
        public virtual DbSet<Config.ConfigString> ConfigStrings { get; set; }
       
    }
}
