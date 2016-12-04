namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                        IsPassed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        ExhibitID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                        ExhibitTypeID = c.Int(nullable: false),
                        ArticleID = c.Int(),
                        Article_ArticleID = c.Guid(),
                        ExhibitType_ExhibitTypeID = c.Guid(),
                    })
                .PrimaryKey(t => t.ExhibitID)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleID)
                .ForeignKey("dbo.ExhibitTypes", t => t.ExhibitType_ExhibitTypeID)
                .Index(t => t.Article_ArticleID)
                .Index(t => t.ExhibitType_ExhibitTypeID);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
            CreateTable(
                "dbo.ExhibitTypes",
                c => new
                    {
                        ExhibitTypeID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExhibitTypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EventImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.EventImages", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventExhibits", "ExhibitID", "dbo.Exhibits");
            DropForeignKey("dbo.EventExhibits", "EventID", "dbo.Events");
            DropForeignKey("dbo.ExhibitImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.ExhibitImages", "ExhibitID", "dbo.Exhibits");
            DropForeignKey("dbo.Exhibits", "ExhibitType_ExhibitTypeID", "dbo.ExhibitTypes");
            DropForeignKey("dbo.Exhibits", "Article_ArticleID", "dbo.Articles");
            DropIndex("dbo.EventImages", new[] { "ImageID" });
            DropIndex("dbo.EventImages", new[] { "EventID" });
            DropIndex("dbo.EventExhibits", new[] { "ExhibitID" });
            DropIndex("dbo.EventExhibits", new[] { "EventID" });
            DropIndex("dbo.ExhibitImages", new[] { "ImageID" });
            DropIndex("dbo.ExhibitImages", new[] { "ExhibitID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Exhibits", new[] { "ExhibitType_ExhibitTypeID" });
            DropIndex("dbo.Exhibits", new[] { "Article_ArticleID" });
            DropTable("dbo.EventImages");
            DropTable("dbo.EventExhibits");
            DropTable("dbo.ExhibitImages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ExhibitTypes");
            DropTable("dbo.Articles");
            DropTable("dbo.Exhibits");
            DropTable("dbo.Events");
            DropTable("dbo.Images");
        }
    }
}
