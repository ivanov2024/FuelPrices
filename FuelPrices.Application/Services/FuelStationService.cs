using FuelPrices.Application.Common.Interfaces;
using FuelPrices.Application.DTOs.Prices;
using FuelPrices.Application.DTOs.Stations;
using FuelPrices.Application.Interfaces;
using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelPrices.Application.Services
{
    public class FuelStationService : IFuelStationService
    {
        private readonly IApplicationDbContext _context;

        public FuelStationService(IApplicationDbContext context)
            => _context = context;

        public async Task<List<FuelStationDto>> GetFuelStationsByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return [];
            }

            return await _context.FuelStations
                .AsNoTracking()
                .Where(s => s.Location.Contains(location))
                .OrderBy(s => s.Location)
                .Select(s => new FuelStationDto
                {
                    Id = s.Id,
                    FuelCompanyId = s.FuelCompanyId,
                    CompanyName = s.FuelCompany.Name,
                    Location = s.Location
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<List<FuelStationDto>> GetFuelStationsByCompanyIdAsync(int fuelCompanyId, CancellationToken cancellationToken = default)
        {
            return await _context.FuelStations
                .AsNoTracking()
                .Where(s => s.FuelCompanyId == fuelCompanyId)
                .OrderBy(s => s.Location)
                .Select(s => new FuelStationDto
                {
                    Id = s.Id,
                    FuelCompanyId = s.FuelCompanyId,
                    CompanyName = s.FuelCompany.Name,
                    Location = s.Location
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<FuelStationDetailsDto?> GetFuelStationDetailsByIdAsync(int fuelStationId, CancellationToken cancellationToken = default)
        {
            return await _context.FuelStations
                .AsNoTracking()
                .Where(s => s.Id == fuelStationId)
                .Select(s => new FuelStationDetailsDto
                {
                    Id = s.Id,
                    FuelCompanyId = s.FuelCompanyId,
                    CompanyName = s.FuelCompany.Name,
                    Location = s.Location,
                    Prices = s.FuelPrices
                        .Select(fp => new FuelPriceDto
                        {
                            Id = fp.Id,
                            Price = fp.Price,
                            FuelType = fp.FuelType,
                            LastUpdated = fp.LastUpdated,
                            FuelStationId = fp.FuelStationId
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<FuelStationDto> CreateFuelStationAsync(CreateFuelStationDto dto, CancellationToken cancellationToken = default)
        {
            bool companyExists = await _context.FuelCompanies
                .AnyAsync(c => c.Id == dto.FuelCompanyId, cancellationToken);

            if (!companyExists)
            {
                throw new KeyNotFoundException($"Fuel company with ID '{dto.FuelCompanyId}' does not exist.");
            }

            var station = new FuelStation
            {
                FuelCompanyId = dto.FuelCompanyId,
                Location = dto.Location
            };

            await _context.FuelStations.AddAsync(station, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var companyName = await _context.FuelCompanies
                .Where(c => c.Id == station.FuelCompanyId)
                .Select(c => c.Name)
                .FirstAsync(cancellationToken);

            return new FuelStationDto
            {
                Id = station.Id,
                FuelCompanyId = station.FuelCompanyId,
                CompanyName = companyName,
                Location = station.Location
            };
        }

        public async Task UpdateFuelStationAsync(int id, CreateFuelStationDto dto, CancellationToken cancellationToken = default)
        {
            var station = await _context.FuelStations
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (station == null)
            {
                throw new KeyNotFoundException($"Fuel station with ID '{id}' does not exist.");
            }

            bool companyExists = await _context.FuelCompanies
                .AnyAsync(c => c.Id == dto.FuelCompanyId, cancellationToken);

            if (!companyExists)
            {
                throw new KeyNotFoundException($"Fuel company with ID '{dto.FuelCompanyId}' does not exist.");
            }

            station.FuelCompanyId = dto.FuelCompanyId;
            station.Location = dto.Location;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteFuelStationAsync(int id, CancellationToken cancellationToken = default)
        {
            var station = await _context.FuelStations
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (station == null)
            {
                throw new KeyNotFoundException($"Fuel station with ID '{id}' does not exist.");
            }

            _context.FuelStations.Remove(station);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
