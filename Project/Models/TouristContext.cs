namespace Project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TouristContext : DbContext
    {
        public TouristContext()
            : base("name=TouristContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ExceptionDetail> ExceptionDetails { get; set; }
        public virtual DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Attractions)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.IdCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.IdCity)
                .WillCascadeOnDelete(false);
        }
    }
}
