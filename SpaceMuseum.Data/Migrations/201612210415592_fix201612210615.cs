namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix201612210615 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Exhibits", "ExhibitTypeID");
            AddForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes", "ExhibitTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "ExhibitTypeID" });
            DropColumn("dbo.Exhibits", "ExhibitTypeID");
        }
    }
}
