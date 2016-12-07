namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix201612070159 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "Article_ArticleID", "dbo.Articles");
            DropIndex("dbo.Exhibits", new[] { "Article_ArticleID" });
            DropIndex("dbo.Exhibits", new[] { "ExhibitType_ExhibitTypeID" });
            DropColumn("dbo.Exhibits", "ExhibitTypeID");
            RenameColumn(table: "dbo.Exhibits", name: "ExhibitType_ExhibitTypeID", newName: "ExhibitTypeID");
            CreateTable(
                "dbo.ExhibitArticles",
                c => new
                    {
                        ExhibitID = c.Guid(nullable: false),
                        ArticleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExhibitID, t.ArticleID })
                .ForeignKey("dbo.Exhibits", t => t.ExhibitID, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .Index(t => t.ExhibitID)
                .Index(t => t.ArticleID);
            
            AddColumn("dbo.Articles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Guid());
            AlterColumn("dbo.Articles", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Exhibits", "ExhibitTypeID");
            DropColumn("dbo.Exhibits", "ArticleID");
            DropColumn("dbo.Exhibits", "Article_ArticleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exhibits", "Article_ArticleID", c => c.Guid());
            AddColumn("dbo.Exhibits", "ArticleID", c => c.Int());
            DropForeignKey("dbo.ExhibitArticles", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.ExhibitArticles", "ExhibitID", "dbo.Exhibits");
            DropIndex("dbo.ExhibitArticles", new[] { "ArticleID" });
            DropIndex("dbo.ExhibitArticles", new[] { "ExhibitID" });
            DropIndex("dbo.Exhibits", new[] { "ExhibitTypeID" });
            AlterColumn("dbo.Articles", "Description", c => c.String());
            AlterColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "Name");
            DropTable("dbo.ExhibitArticles");
            RenameColumn(table: "dbo.Exhibits", name: "ExhibitTypeID", newName: "ExhibitType_ExhibitTypeID");
            AddColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Exhibits", "ExhibitType_ExhibitTypeID");
            CreateIndex("dbo.Exhibits", "Article_ArticleID");
            AddForeignKey("dbo.Exhibits", "Article_ArticleID", "dbo.Articles", "ArticleID");
        }
    }
}
