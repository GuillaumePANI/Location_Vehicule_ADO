﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Location_voitures_ADO_console
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LOCATIONEntities : DbContext
    {
        public LOCATIONEntities()
            : base("name=LOCATIONEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORIE> CATEGORIE { get; set; }
        public virtual DbSet<CLIENT> CLIENT { get; set; }
        public virtual DbSet<LOUE> LOUE { get; set; }
        public virtual DbSet<MARQUE> MARQUE { get; set; }
        public virtual DbSet<VEHICULE> VEHICULE { get; set; }
    }
}