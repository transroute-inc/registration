﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransRoute.Entities.Db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TransRouteEntities : DbContext
    {
        public TransRouteEntities()
            : base("name=TransRouteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArchiveNo> ArchiveNoes { get; set; }
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public virtual DbSet<CustomerAccounnt> CustomerAccounnts { get; set; }
    }
}