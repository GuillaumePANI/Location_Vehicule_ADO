namespace Location_voitures_ADO_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AJOUT_PAYS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Pays", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Pays");
        }
    }
}
