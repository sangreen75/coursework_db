namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentCalls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartCallTime = c.DateTime(nullable: false),
                        EndCallTime = c.DateTime(nullable: false),
                        CallCenter_Id = c.Int(),
                        Client_Id = c.Int(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CallCenters", t => t.CallCenter_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Managers", t => t.Manager_Id)
                .Index(t => t.CallCenter_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.CallCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Income = c.Int(nullable: false),
                        Region = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.Int(nullable: false),
                        Effiency = c.Int(nullable: false),
                        StartWorkTime = c.DateTime(nullable: false),
                        EndWorkTime = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        CallCenter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CallCenters", t => t.CallCenter_Id)
                .Index(t => t.CallCenter_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentCalls", "Manager_Id", "dbo.Managers");
            DropForeignKey("dbo.Managers", "CallCenter_Id", "dbo.CallCenters");
            DropForeignKey("dbo.AppointmentCalls", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.AppointmentCalls", "CallCenter_Id", "dbo.CallCenters");
            DropIndex("dbo.Managers", new[] { "CallCenter_Id" });
            DropIndex("dbo.AppointmentCalls", new[] { "Manager_Id" });
            DropIndex("dbo.AppointmentCalls", new[] { "Client_Id" });
            DropIndex("dbo.AppointmentCalls", new[] { "CallCenter_Id" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Managers");
            DropTable("dbo.Clients");
            DropTable("dbo.CallCenters");
            DropTable("dbo.AppointmentCalls");
        }
    }
}
