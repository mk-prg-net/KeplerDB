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
        public KeplerDBContext() : base("KeplerBiContext") { }

        public DbSet<CelesticalBodyTypeDescriptor> CelesticalBodyTypes { get; set; }

        public DbSet<CelestialBodyBase> CelesticalBodies { get; set; }
        public DbSet<NaturalCelesticalBodies.NaturalCelesticalBody> NCBs { get; set; }

        //public DbSet<NaturalCelesticalBodies.Asteroid> Asteroids { get; set; }
        //public DbSet<NaturalCelesticalBodies.BigBang> BigBangs { get; set; }
        //public DbSet<NaturalCelesticalBodies.Comet> Comets { get; set; }
        //public DbSet<NaturalCelesticalBodies.Galaxy> Galaxies { get; set; }
        //public DbSet<NaturalCelesticalBodies.GalaxyCore> GalaxyCores { get; set; }
        //public DbSet<NaturalCelesticalBodies.Moon> Moons { get; set; }
        //public DbSet<NaturalCelesticalBodies.Planet> Planets { get; set; }
        //public DbSet<NaturalCelesticalBodies.Star> Stars { get; set; }

        public DbSet<SpaceShips.SpaceShip> SpaceShips { get; set; }
        //public DbSet<SpaceShips.MannedSpacecraft> MannedSpacecrafts { get; set; }

        public DbSet<SpaceShips.SpaceshipTask> Tasks { get; set; }
        public DbSet<SpaceShips.Application> Applications { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Orbit> Orbits { get; set; }
        public DbSet<CelesticalBodySystem> CelesticalBodySystems { get; set; }
       
    }
}
