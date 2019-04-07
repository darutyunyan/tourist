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
        public virtual DbSet<ExceptionDetail> ExceptionDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
