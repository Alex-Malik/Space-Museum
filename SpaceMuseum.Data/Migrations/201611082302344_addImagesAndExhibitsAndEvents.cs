namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImagesAndExhibitsAndEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        URL = c.String(nullable: false, maxLength: 256),
                        MIME = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        ExhibitID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExhibitID);
            
            CreateTable(
                "dbo.ExhibitImages",
                c => new
                    {
                        ExhibitID = c.Guid(nullable: false),
                        ImageID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExhibitID, t.ImageID })
                .ForeignKey("dbo.Exhibits", t => t.ExhibitID, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.ExhibitID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.EventExhibits",
                c => new
                    {
                        EventID = c.Guid(nullable: false),
                        ExhibitID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventID, t.ExhibitID })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Exhibits", t => t.ExhibitID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.ExhibitID);
            
            CreateTable(
                "dbo.EventImages",
                c => new
                    {
                        EventID = c.Guid(nullable: false),
                        ImageID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventID, t.ImageID })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.ImageID);
            
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.EventImages", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventExhibits", "ExhibitID", "dbo.Exhibits");
            DropForeignKey("dbo.EventExhibits", "EventID", "dbo.Events");
            DropForeignKey("dbo.ExhibitImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.ExhibitImages", "ExhibitID", "dbo.Exhibits");
            DropIndex("dbo.EventImages", new[] { "ImageID" });
            DropIndex("dbo.EventImages", new[] { "EventID" });
            DropIndex("dbo.EventExhibits", new[] { "ExhibitID" });
            DropIndex("dbo.EventExhibits", new[] { "EventID" });
            DropIndex("dbo.ExhibitImages", new[] { "ImageID" });
            DropIndex("dbo.ExhibitImages", new[] { "ExhibitID" });
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String());
            DropTable("dbo.EventImages");
            DropTable("dbo.EventExhibits");
            DropTable("dbo.ExhibitImages");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Events");
            DropTable("dbo.Images");
        }
    }
}
