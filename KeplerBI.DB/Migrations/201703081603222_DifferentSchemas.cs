namespace KeplerBI.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DifferentSchemas : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.CelestialBodyBases", newSchema: "kosmos");
            MoveTable(name: "dbo.Asteroids", newSchema: "kosmos");
            MoveTable(name: "dbo.BigBangs", newSchema: "kosmos");
            MoveTable(name: "dbo.Comets", newSchema: "kosmos");
            MoveTable(name: "dbo.Galaxies", newSchema: "kosmos");
            MoveTable(name: "dbo.GalaxyCores", newSchema: "kosmos");
            MoveTable(name: "dbo.Moons", newSchema: "kosmos");
            MoveTable(name: "dbo.Planets", newSchema: "kosmos");
            MoveTable(name: "dbo.Stars", newSchema: "kosmos");
            MoveTable(name: "dbo.Orbits", newSchema: "kosmos");
            MoveTable(name: "dbo.CelesticalBodyTypeDescriptors", newSchema: "kosmos");
            MoveTable(name: "dbo.CelesticalBodySystems", newSchema: "kosmos");
            MoveTable(name: "dbo.ConfigStrings", newSchema: "admin");
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                        Caption = c.String(maxLength: 1000),
                        Created = c.DateTime(nullable: false),
                        HightInPix = c.Int(nullable: false),
                        Img = c.Binary(),
                        WidhtInPix = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("kosmos.CelestialBodyBases", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "admin.Logs",
                c => new
                    {
                        LogFileId = c.Int(nullable: false, identity: true),
                        LogTime = c.DateTime(nullable: false),
                        Message = c.String(maxLength: 1000),
                        Type = c.Int(nullable: false),
                        User = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.LogFileId);
            
            AddColumn("kosmos.CelestialBodyBases", "RankSum", c => c.Int(nullable: false));
            AddColumn("kosmos.CelestialBodyBases", "RankCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ImageId", "kosmos.CelestialBodyBases");
            DropIndex("dbo.Images", new[] { "ImageId" });
            DropColumn("kosmos.CelestialBodyBases", "RankCount");
            DropColumn("kosmos.CelestialBodyBases", "RankSum");
            DropTable("admin.Logs");
            DropTable("dbo.Images");
            MoveTable(name: "admin.ConfigStrings", newSchema: "dbo");
            MoveTable(name: "kosmos.CelesticalBodySystems", newSchema: "dbo");
            MoveTable(name: "kosmos.CelesticalBodyTypeDescriptors", newSchema: "dbo");
            MoveTable(name: "kosmos.Orbits", newSchema: "dbo");
            MoveTable(name: "kosmos.Stars", newSchema: "dbo");
            MoveTable(name: "kosmos.Planets", newSchema: "dbo");
            MoveTable(name: "kosmos.Moons", newSchema: "dbo");
            MoveTable(name: "kosmos.GalaxyCores", newSchema: "dbo");
            MoveTable(name: "kosmos.Galaxies", newSchema: "dbo");
            MoveTable(name: "kosmos.Comets", newSchema: "dbo");
            MoveTable(name: "kosmos.BigBangs", newSchema: "dbo");
            MoveTable(name: "kosmos.Asteroids", newSchema: "dbo");
            MoveTable(name: "kosmos.CelestialBodyBases", newSchema: "dbo");
        }
    }
}
