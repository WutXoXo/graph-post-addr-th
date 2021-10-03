using Microsoft.EntityFrameworkCore;
using TH.POST.Address.Domain.Entities;

namespace TH.POST.Address.Persistence.Context
{
    public class AppSQLServerContext : DbContext
    {
        public AppSQLServerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GeographyEntity> Geographies { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DbSet<AmphurEntity> Amphures { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<GeographyEntity>()
                .HasMany(p => p.Provinces)
                .WithOne(p => p.Geography!)
                .HasForeignKey(p => p.GeographyId);

            modelBuilder
                .Entity<ProvinceEntity>()
                .HasOne(p => p.Geography)
                .WithMany(p => p.Provinces)
                .HasForeignKey(p => p.GeographyId);

            modelBuilder
                .Entity<ProvinceEntity>()
                .HasMany(p => p.Amphures)
                .WithOne(p => p.Province!)
                .HasForeignKey(p => p.ProvinceId);

            modelBuilder
                .Entity<AmphurEntity>()
                .HasOne(p => p.Province)
                .WithMany(p => p.Amphures)
                .HasForeignKey(p => p.ProvinceId);


            modelBuilder
                .Entity<AmphurEntity>()
                .HasMany(p => p.Districts)
                .WithOne(p => p.Amphur!)
                .HasForeignKey(p => p.AmphurId);

            modelBuilder
                .Entity<DistrictEntity>()
                .HasOne(p => p.Amphur)
                .WithMany(p => p.Districts)
                .HasForeignKey(p => p.AmphurId);


            modelBuilder.Entity<GeographyEntity>()
            .HasData(ServiceRegistration.GetGeographies());

            modelBuilder.Entity<ProvinceEntity>()
            .HasData(ServiceRegistration.GetProvinces());

            modelBuilder.Entity<AmphurEntity>()
            .HasData(ServiceRegistration.GetAmphures());

            modelBuilder.Entity<DistrictEntity>()
            .HasData(ServiceRegistration.GetDistricts());
        }
    }
}
