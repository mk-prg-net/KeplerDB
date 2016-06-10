namespace KeplerBI.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfigStrings",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConfigStrings");
        }
    }
}
