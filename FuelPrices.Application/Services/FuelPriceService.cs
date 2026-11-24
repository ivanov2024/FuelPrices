using FuelPrices.Application.Common.Interfaces;
using FuelPrices.Application.DTOs.Prices;
using FuelPrices.Application.Interfaces;
using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelPrices.Application.Services
{
    public class FuelPriceService : IFuelPriceService
    {
        private readonly IApplicationDbContext _context;

        public FuelPriceService(IApplicationDbContext context)
            => _context = context;
        

        public async Task<List<FuelPriceDto>> GetFuelPriceAsync(int stationId, CancellationToken cancellationToken = default)
            => await _context
                .FuelPrices
                .Where(fp => fp.FuelStationId == stationId)
                .Select(fp => new FuelPriceDto
                {
                    Id = fp.Id,
                    Price = fp.Price,
                    FuelType = fp.FuelType,
                    LastUpdated = fp.LastUpdated,
                    FuelStationId = fp.FuelStationId
                })
                .ToListAsync(cancellationToken);

        public async Task<List<FuelPriceHistoryDto>> GetFuelPriceHistoryAsync(int fuelPriceId, CancellationToken cancellationToken = default)
            => await _context
                .FuelPriceHistories
                .Where(fph => fph.FuelPriceId == fuelPriceId)
                .Select(fph => new FuelPriceHistoryDto
                {
                    Id = fph.Id,
                    FuelPriceId = fph.FuelPriceId,
                    Price = fph.Price,
                    ChangedAt = fph.ChangedAt
                })
                .ToListAsync(cancellationToken);

        public async Task UpdateFuelPriceAsync(UpdateFuelPriceDto dto, CancellationToken cancellationToken = default)
        {
            var fuelPrice = await _context
                .FuelPrices
                .FirstOrDefaultAsync(fp => fp.Id == dto.Id, cancellationToken);

            if (fuelPrice == null)
            {
                throw new KeyNotFoundException($"Fuel price with ID '{dto.Id}' does not exist.");
            }

            var historyRecord = new FuelPriceHistory
            {
                FuelPriceId = fuelPrice.Id,
                Price = fuelPrice.Price,
                ChangedAt = DateTime.UtcNow
            };

            await _context.FuelPriceHistories.AddAsync(historyRecord, cancellationToken);

            fuelPrice.Price = dto.Price;
            fuelPrice.LastUpdated = DateTime.UtcNow;
                
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
