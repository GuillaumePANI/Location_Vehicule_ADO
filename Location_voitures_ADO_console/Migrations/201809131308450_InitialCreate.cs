namespace Location_voitures_ADO_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(nullable: false),
                        City = c.String(nullable: false, maxLength: 50),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id_Location = c.Int(nullable: false, identity: true),
                        IdCustomer = c.Int(nullable: false),
                        Id_Vehicule = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Location)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Customer_Id" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
        }
    }
}
