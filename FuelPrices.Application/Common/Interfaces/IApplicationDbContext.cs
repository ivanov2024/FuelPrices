using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelPrices.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<FuelCompany> FuelCompanies { get; }
        DbSet<FuelStation> FuelStations { get; }
        DbSet<FuelPrice> FuelPrices { get; }
        DbSet<FuelPriceHistory> FuelPriceHistories { get; }
        DbSet<StationEmployee> StationEmployees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
