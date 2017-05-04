using Microsoft.EntityFrameworkCore;

namespace Carsales.Core.Domain
{
    public class CarsalesContext : DbContext
    {
        public CarsalesContext(DbContextOptions<CarsalesContext> options) : base(options) {}
        
        public CarsalesContext() : base() {}

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Enquiry> Enquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Car>().Property(c => c.Comments).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Email).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Make).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Model).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.PriceType).IsRequired().HasDefaultValue(PriceType.POA);
            modelBuilder.Entity<Car>().Property(c => c.Year).IsRequired();

            modelBuilder.Entity<Enquiry>().ToTable("Enquiry");
            modelBuilder.Entity<Enquiry>().Property(e => e.Email).IsRequired();
            modelBuilder.Entity<Enquiry>().Property(e => e.Name).IsRequired();
        }
    }
}