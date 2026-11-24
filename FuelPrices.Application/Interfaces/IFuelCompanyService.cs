using FuelPrices.Application.DTOs.Companies;

namespace FuelPrices.Application.Interfaces
{
    public interface IFuelCompanyService
    {
        Task<List<FuelCompanyDto>> GetCompaniesAsync(CancellationToken cancellationToken = default);
        Task<FuelCompanyDto?> GetCompanyByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<FuelCompanyDto> CreateCompanyAsync(CreateFuelCompanyDto dto, CancellationToken cancellationToken = default);
        Task UpdateCompanyAsync(int id, CreateFuelCompanyDto dto, CancellationToken cancellationToken = default);
        Task DeleteCompanyAsync(int id, CancellationToken cancellationToken = default);
    }
}