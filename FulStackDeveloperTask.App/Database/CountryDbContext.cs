namespace FulStackDeveloperTask.App.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;
    using Model;

    public partial class CountryDbContext : DbContext
    {
        public CountryDbContext()
            : base("name=CountryDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Country> CountryList { get; set; }
        public virtual DbSet<Region> RegionList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasMany(e => e.CountryList)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
        }
    }
}
