using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NCB = KeplerBI.DB.NaturalCelesticalBodies;


namespace KeplerBI.DB
{
    partial class KeplerDBContext
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CelesticalBodyTypeDescriptor>().HasKey(e => e.TypeID);

            modelBuilder.Entity<CelestialBodyBase>().Ignore<mko.Newton.Mass>(e => e.Mass);

            // Festlegen der Eigenschaft, welche über den Typ der Entities entscheidet 
            modelBuilder.Entity<CelestialBodyBase>().Map(cfg => cfg.Requires<CelesticalBodyType>(e => e.Type));

            //modelBuilder.Entity<CelestialBodyBase>().Map<SpaceShips.MannedSpacecraft>(cfg => cfg.ToTable("MannedSpacecraft"));
            modelBuilder.Entity<CelestialBodyBase>().Map<SpaceShips.SpaceShip>(cfg => cfg.ToTable("SpaceShip"));

            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Asteroid>(cfg => cfg.ToTable("Asteroids"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.BigBang>(cfg => cfg.ToTable("BigBangs"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Comet>(cfg => cfg.ToTable("Comets"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Galaxy>(cfg => cfg.ToTable("Galaxies"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.GalaxyCore>(cfg => cfg.ToTable("GalaxyCores"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Moon>(cfg => cfg.ToTable("Moons"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Planet>(cfg => cfg.ToTable("Planets"));
            modelBuilder.Entity<CelestialBodyBase>().Map<NCB.Star>(cfg => cfg.ToTable("Stars"));
            //modelBuilder.Entity<CelestialBodyBase>().Map<NCB.NaturalCelesticalBody>(cfg => cfg.ToTable("NCBs"));



            //modelBuilder.Entity<SpaceShips.SpaceShip>().HasEntitySetName("AreasOfApplication").HasMany<SpaceShips.AreaOfApplication>(e => e.AreasOfApplication);

            modelBuilder.Entity<Orbit>().Ignore<mko.Newton.Length>(e => e.SemiMajorAxis).Ignore<mko.Newton.Velocity>(e => e.MeanVelocityOfCirculation);

            //modelBuilder.Entity<SpaceShips.AreaOfApplication>().ToTable("AreasOfApplication");

            base.OnModelCreating(modelBuilder);
        }
    }
}
