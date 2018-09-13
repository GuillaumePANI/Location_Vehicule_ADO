namespace Location_voitures_ADO_console.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeFist : DbContext
    {
        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<Reservation> reservations { get; set; }





        // Your context has been configured to use a 'CodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Location_voitures_ADO_console.CodeFirst.CodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodeFirst' 
        // connection string in the application configuration file.
        public CodeFist()
            : base("name=CodeFirst")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}