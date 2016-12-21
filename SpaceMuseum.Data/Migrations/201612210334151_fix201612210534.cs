namespace SpaceMuseum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix201612210534 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "ExhibitTypeID" });
            AlterColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Guid(nullable: false));
            AlterColumn("dbo.ExhibitTypes", "Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Exhibits", "ExhibitTypeID");
            AddForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes", "ExhibitTypeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes");
            DropIndex("dbo.Exhibits", new[] { "ExhibitTypeID" });
            AlterColumn("dbo.ExhibitTypes", "Name", c => c.String());
            AlterColumn("dbo.Exhibits", "ExhibitTypeID", c => c.Guid());
            CreateIndex("dbo.Exhibits", "ExhibitTypeID");
            AddForeignKey("dbo.Exhibits", "ExhibitTypeID", "dbo.ExhibitTypes", "ExhibitTypeID");
        }
    }
}
