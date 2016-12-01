using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminalsDB.Service.Models
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
        }

        public virtual DbSet<Criminal> Criminals { get; set; }
        public virtual DbSet<Crime> Crimes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Criminal>()
            .HasMany(s => s.CriminalHistory)
            .WithMany(c => c.Criminals)
            .Map(cs =>
            {
                cs.MapLeftKey("CriminalId");
                cs.MapRightKey("CrimeID");
                cs.ToTable("CriminalCrime");
            });
        }
    }
}
