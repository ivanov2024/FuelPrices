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

        public async Task<List<FuelPriceDto>> GetFuelPricesByStationIdAsync(int stationId, CancellationToken cancellationToken = default)
            => await _context
                .FuelPrices
                .AsNoTracking()
                .Where(fp => fp.FuelStationId == stationId)
                .OrderBy(fp => fp.FuelType)
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
                .AsNoTracking()
                .Where(fph => fph.FuelPriceId == fuelPriceId)
                .OrderByDescending(fph => fph.ChangedAt)
                .Select(fph => new FuelPriceHistoryDto
                {
                    Id = fph.Id,
                    FuelPriceId = fph.FuelPriceId,
                    Price = fph.Price,
                    ChangedAt = fph.ChangedAt
                })
                .ToListAsync(cancellationToken);

        public async Task<FuelPriceDto> CreateFuelPriceAsync(CreateFuelPriceDto dto, CancellationToken cancellationToken = default)
        {
            bool stationExists = await _context.FuelStations
                .AnyAsync(s => s.Id == dto.FuelStationId, cancellationToken);

            if (!stationExists)
            {
                throw new KeyNotFoundException($"Fuel station with ID '{dto.FuelStationId}' does not exist.");
            }

            bool priceExists = await _context.FuelPrices
                .AnyAsync(fp => fp.FuelStationId == dto.FuelStationId && fp.FuelType == dto.FuelType, cancellationToken);

            if (priceExists)
            {
                throw new InvalidOperationException($"A price for '{dto.FuelType}' already exists at station '{dto.FuelStationId}'.");
            }

            var fuelPrice = new FuelPrice
            {
                Price = dto.Price,
                FuelType = dto.FuelType,
                LastUpdated = DateTime.UtcNow,
                FuelStationId = dto.FuelStationId
            };

            await _context.FuelPrices.AddAsync(fuelPrice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new FuelPriceDto
            {
                Id = fuelPrice.Id,
                Price = fuelPrice.Price,
                FuelType = fuelPrice.FuelType,
                LastUpdated = fuelPrice.LastUpdated,
                FuelStationId = fuelPrice.FuelStationId
            };
        }

        public async Task UpdateFuelPriceAsync(UpdateFuelPriceDto dto, CancellationToken cancellationToken = default)
        {
            var fuelPrice = await _context.FuelPrices
                .FirstOrDefaultAsync(fp => fp.Id == dto.Id, cancellationToken);

            if (fuelPrice == null)
            {
                throw new KeyNotFoundException($"Fuel price with ID '{dto.Id}' does not exist.");
            }

            if (fuelPrice.Price == dto.Price) return;

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