namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix201612210612 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "ExhibitTypeID" });
            DropColumn("dbo.Exhibits", "ExhibitTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Exhibits", "ExhibitTypeID");
            AddForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes", "ExhibitTypeID", cascadeDelete: true);
        }
    }
}
