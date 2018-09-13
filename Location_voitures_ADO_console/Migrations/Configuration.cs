namespace Location_voitures_ADO_console.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Location_voitures_ADO_console.CodeFirst.CodeFist>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Location_voitures_ADO_console.CodeFirst.CodeFist";
        }

        protected override void Seed(Location_voitures_ADO_console.CodeFirst.CodeFist context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
