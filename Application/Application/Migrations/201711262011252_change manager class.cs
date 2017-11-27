namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemanagerclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Managers", "Effiency", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Managers", "Effiency", c => c.Int(nullable: false));
        }
    }
}
