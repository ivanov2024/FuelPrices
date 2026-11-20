using FuelPrices.Domain.Entities;
using FuelPrices.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static FuelPrices.Infrastructure.Data.ConnectionString;

namespace FuelPrices.Infrastructure.Data
{
    public class FuelPricesDbContext : IdentityDbContext<ApplicationUser>
    {
        public FuelPricesDbContext() { }

        public FuelPricesDbContext(DbContextOptions<FuelPricesDbContext> options)
            : base(options)
        {
        }

        public DbSet<FuelCompany> FuelCompanies => Set<FuelCompany>();

        public DbSet<FuelPrice> FuelPrices => Set<FuelPrice>();

        public DbSet<FuelPriceHistory> FuelPriceHistories => Set<FuelPriceHistory>();

        public DbSet<FuelStation> FuelStations => Set<FuelStation>();

        public DbSet<StationEmployee> StationEmployees => Set<StationEmployee>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuelPricesDbContext).Assembly);
        }
    }
}
