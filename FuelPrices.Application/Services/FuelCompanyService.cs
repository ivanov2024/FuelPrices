using FuelPrices.Application.Common.Interfaces;
using FuelPrices.Application.DTOs.Companies;
using FuelPrices.Application.Interfaces;
using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelPrices.Application.Services
{
    public class FuelCompanyService : IFuelCompanyService
    {
        private readonly IApplicationDbContext _context;

        public FuelCompanyService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FuelCompanyDto>> GetCompaniesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.FuelCompanies
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new FuelCompanyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Information = c.Information
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<FuelCompanyDto?> GetCompanyByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.FuelCompanies
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new FuelCompanyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Information = c.Information
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<FuelCompanyDto> CreateCompanyAsync(CreateFuelCompanyDto dto, CancellationToken cancellationToken = default)
        {
            bool exists = await _context.FuelCompanies
                .AnyAsync(c => c.Name == dto.Name, cancellationToken);

            if (exists)
            {
                throw new InvalidOperationException($"Company with name '{dto.Name}' already exists.");
            }

            var company = new FuelCompany
            {
                Name = dto.Name,
                Information = dto.Information
            };

            await _context.FuelCompanies.AddAsync(company, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new FuelCompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Information = company.Information
            };
        }

        public async Task UpdateCompanyAsync(int id, CreateFuelCompanyDto dto, CancellationToken cancellationToken = default)
        {
            var company = await _context.FuelCompanies
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (company == null)
            {
                throw new KeyNotFoundException($"Fuel company with Id {id} was not found.");
            }

            company.Name = dto.Name;
            company.Information = dto.Information;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCompanyAsync(int id, CancellationToken cancellationToken = default)
        {
            var company = await _context.FuelCompanies
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (company == null)
            {
                throw new KeyNotFoundException($"Fuel company with Id {id} was not found.");
            }

            _context.FuelCompanies.Remove(company);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}