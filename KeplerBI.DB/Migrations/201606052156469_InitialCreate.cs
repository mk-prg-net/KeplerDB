namespace KeplerBI.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CelestialBodyBases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        MassInEarthmasses = c.Double(),
                        MeanSurfaceTemp = c.Double(),
                        GravityInMeterPerSec = c.Double(),
                        PolarDiameterInKilometer = c.Double(),
                        EquatorialDiameterInKilometer = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelesticalBodyTypeDescriptors", t => t.Type)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.Orbits",
                c => new
                    {
                        SatelliteId = c.Int(nullable: false),
                        CentralBodyId = c.Int(nullable: false),
                        SemiMajorAxisInKilometer = c.Double(nullable: false),
                        MeanVelocitiOfCirculationInKmPerSec = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SatelliteId)
                .ForeignKey("dbo.CelestialBodyBases", t => t.CentralBodyId)
                .ForeignKey("dbo.CelestialBodyBases", t => t.SatelliteId)
                .ForeignKey("dbo.CelesticalBodySystems", t => t.CentralBodyId, cascadeDelete: true)
                .Index(t => t.SatelliteId)
                .Index(t => t.CentralBodyId);
            
            CreateTable(
                "dbo.CelesticalBodyTypeDescriptors",
                c => new
                    {
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.CelesticalBodySystems",
                c => new
                    {
                        CentralBodyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentralBodyId)
                .ForeignKey("dbo.CelestialBodyBases", t => t.CentralBodyId)
                .Index(t => t.CentralBodyId);
            
            CreateTable(
                "dbo.Asteroids",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Albedo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.BigBangs",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Comets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Galaxies",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.GalaxyCores",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Moons",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        HasRings = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        SpectralClass = c.Int(nullable: false),
                        LuminosityInMulitiplesOfSun = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CelestialBodyBases", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stars", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Planets", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Moons", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.GalaxyCores", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Galaxies", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Comets", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.BigBangs", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Asteroids", "ID", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Orbits", "CentralBodyId", "dbo.CelesticalBodySystems");
            DropForeignKey("dbo.CelesticalBodySystems", "CentralBodyId", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.CelestialBodyBases", "Type", "dbo.CelesticalBodyTypeDescriptors");
            DropForeignKey("dbo.Orbits", "SatelliteId", "dbo.CelestialBodyBases");
            DropForeignKey("dbo.Orbits", "CentralBodyId", "dbo.CelestialBodyBases");
            DropIndex("dbo.Stars", new[] { "ID" });
            DropIndex("dbo.Planets", new[] { "ID" });
            DropIndex("dbo.Moons", new[] { "ID" });
            DropIndex("dbo.GalaxyCores", new[] { "ID" });
            DropIndex("dbo.Galaxies", new[] { "ID" });
            DropIndex("dbo.Comets", new[] { "ID" });
            DropIndex("dbo.BigBangs", new[] { "ID" });
            DropIndex("dbo.Asteroids", new[] { "ID" });
            DropIndex("dbo.CelesticalBodySystems", new[] { "CentralBodyId" });
            DropIndex("dbo.Orbits", new[] { "CentralBodyId" });
            DropIndex("dbo.Orbits", new[] { "SatelliteId" });
            DropIndex("dbo.CelestialBodyBases", new[] { "Type" });
            DropTable("dbo.Stars");
            DropTable("dbo.Planets");
            DropTable("dbo.Moons");
            DropTable("dbo.GalaxyCores");
            DropTable("dbo.Galaxies");
            DropTable("dbo.Comets");
            DropTable("dbo.BigBangs");
            DropTable("dbo.Asteroids");
            DropTable("dbo.CelesticalBodySystems");
            DropTable("dbo.CelesticalBodyTypeDescriptors");
            DropTable("dbo.Orbits");
            DropTable("dbo.CelestialBodyBases");
        }
    }
}
