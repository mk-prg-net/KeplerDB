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

            modelBuilder.Entity<CelestialBodyBase>()
                .Ignore<mko.Newton.Mass>(e => e.Mass)

                // Festlegen der Eigenschaft, welche über den Typ der Entities entscheidet 
                .Map(cfg => cfg.Requires<CelesticalBodyType>(e => e.Type));



            //modelBuilder.Entity<CelestialBodyBase>().Map<SpaceShips.MannedSpacecraft>(cfg => cfg.ToTable("MannedSpacecraft"));
            modelBuilder.Entity<CelestialBodyBase>()
                //.Map<SpaceShips.SpaceShip>(cfg => cfg.ToTable("SpaceShip"))
                .Map<NCB.Asteroid>(cfg => cfg.ToTable("Asteroids"))
                .Map<NCB.BigBang>(cfg => cfg.ToTable("BigBangs"))
                .Map<NCB.Comet>(cfg => cfg.ToTable("Comets"))
                .Map<NCB.Galaxy>(cfg => cfg.ToTable("Galaxies"))
                .Map<NCB.GalaxyCore>(cfg => cfg.ToTable("GalaxyCores"))
                .Map<NCB.Moon>(cfg => cfg.ToTable("Moons"))
                .Map<NCB.Planet>(cfg => cfg.ToTable("Planets"))
                .Map<NCB.Star>(cfg => cfg.ToTable("Stars"));
            //modelBuilder.Entity<CelestialBodyBase>().Map<NCB.NaturalCelesticalBody>(cfg => cfg.ToTable("NCBs"));


            //modelBuilder.Entity<SpaceShips.SpaceShip>().HasEntitySetName("AreasOfApplication").HasMany<SpaceShips.AreaOfApplication>(e => e.AreasOfApplication);

            modelBuilder.Entity<Orbit>()
                        .Ignore<mko.Newton.Length>(e => e.SemiMajorAxis)
                        .Ignore<mko.Newton.Velocity>(e => e.MeanVelocityOfCirculation);

            // Beziehungen definieren
            modelBuilder.Entity<Orbit>()
                        .HasRequired<CelestialBodyBase>(r => r.Satellite).WithMany().HasForeignKey(r => r.SatelliteId).WillCascadeOnDelete(false);
                        
            modelBuilder.Entity<Orbit>()
                        .HasRequired<CelestialBodyBase>(r => r.CentralBody).WithMany().HasForeignKey(r => r.CentralBodyId).WillCascadeOnDelete(false);
            

            //modelBuilder.Entity<SpaceShips.AreaOfApplication>().ToTable("AreasOfApplication");

            base.OnModelCreating(modelBuilder);
        }
    }
}
