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

            modelBuilder.Entity<CelesticalBodyTypeDescriptor>().HasKey(e => e.Type);

            modelBuilder.Entity<CelestialBodyBase>()
                .Ignore<mko.Newton.Mass>(e => e.Mass)

                // Festlegen der Eigenschaft, welche über den Typ der Entities entscheidet 
                .Map(cfg => cfg.Requires<CelesticalBodyType>(e => e.Type));


            modelBuilder.Entity<CelestialBodyBase>()
                .HasRequired<CelesticalBodyTypeDescriptor>(r => r.TypeDescriptor).WithMany().WillCascadeOnDelete(false);



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


            modelBuilder.Entity<CelestialBodyBase>()
                .HasOptional<Orbit>(r => r.Orbit).WithRequired();


            //modelBuilder.Entity<SpaceShips.SpaceShip>().HasEntitySetName("AreasOfApplication").HasMany<SpaceShips.AreaOfApplication>(e => e.AreasOfApplication);

            modelBuilder.Entity<Orbit>()
                        .HasKey(r => r.SatelliteId)
                        .Ignore<mko.Newton.Length>(e => e.SemiMajorAxis)
                        .Ignore<mko.Newton.Velocity>(e => e.MeanVelocityOfCirculation);

            // 1:n Beziehung zwischen Orbit und CelesticalBodyBase: Orbit.CentralBodyId == CelesticalBodyBase.ID
            modelBuilder.Entity<Orbit>()
                        .HasRequired<CelestialBodyBase>(r => r.CentralBody).WithMany().HasForeignKey(r => r.CentralBodyId).WillCascadeOnDelete(false);
                       
            // 1:1 Beziehung zwischen Orbit und CelesticalBodyBase: Orbit.SatelitId == CelesticalBodyBase.ID
            modelBuilder.Entity<Orbit>()
                        .HasRequired<CelestialBodyBase>(r => r.Satellite).WithOptional(r => r.Orbit).WillCascadeOnDelete(false);

            
            modelBuilder.Entity<CelesticalBodySystem>()
                        .HasKey(r => r.CentralBodyId)
                        .HasRequired<CelestialBodyBase>(r => r.CentralBody).WithOptional().WillCascadeOnDelete(false);
            

            //modelBuilder.Entity<SpaceShips.AreaOfApplication>().ToTable("AreasOfApplication");

            modelBuilder.Entity<Config.ConfigString>().HasKey(r => r.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
