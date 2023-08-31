using LogisticSolution.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LogisticSolution.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<DeliverySchedule>? DeliverySchedules { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliverySchedule>().HasKey(ds => ds.DeliveryScheduleId);
            modelBuilder.Entity<DeliverySchedule>(ds =>
            {
                ds.Property(d => d.DeliveryDate).HasColumnType("date").IsRequired();
                ds.Property(d => d.RecordDate).HasColumnType("date").IsRequired();
                ds.Property(d => d.TransportId).HasColumnType("varchar(8)").IsRequired();
                ds.Property(d => d.GuideNumber).HasColumnType("varchar(10)").IsRequired();
                ds.Property(d => d.Price).HasColumnType("decimal(6, 2)").IsRequired();
            });

            modelBuilder.Entity<Location>().HasKey(l => l.LocationId);
            modelBuilder.Entity<Location>(l =>
            {
                l.Property(ui => ui.Name).HasColumnType("varchar(40)").IsRequired();
                l.Property(ui => ui.LocationType).HasConversion<int>().IsRequired();
            });

            modelBuilder.Entity<Location>()
                        .HasMany(l => l.DeliverySchedules)
                        .WithOne(ds => ds.Location)
                        .HasForeignKey(ds => ds.LocationId)
                        .IsRequired();

            modelBuilder.Entity<ProductCategory>().HasKey(pc => pc.ProductCategoryId);
            modelBuilder.Entity<ProductCategory>(pc =>
            {
                pc.Property(ui => ui.Name).HasColumnType("varchar(40)").IsRequired();
            });
            modelBuilder.Entity<ProductCategory>()
                        .HasMany(pc => pc.DeliverySchedules)
                        .WithOne(ds => ds.ProductCategory)
                        .HasForeignKey(ds => ds.ProductCategoryId)
                        .IsRequired();

            modelBuilder.Entity<User>().HasKey(user => user.UserId);
            modelBuilder.Entity<User>(u =>
            {
                u.Property(ui => ui.Name).HasColumnType("varchar(40)").IsRequired();
                u.Property(ui => ui.LastName).HasColumnType("varchar(40)").IsRequired();
                u.Property(ui => ui.Email).HasColumnType("varchar(200)").IsRequired();
            });
            modelBuilder.Entity<User>()
                        .HasMany(u => u.DeliverySchedules)
                        .WithOne(ds => ds.User)
                        .HasForeignKey(ds => ds.UserId)
                        .IsRequired();

            base.OnModelCreating(modelBuilder);

        }

        internal object Entry<T>()
        {
            throw new NotImplementedException();
        }
    }
}
