using FuelPrices.Application.DTOs.Stations;

namespace FuelPrices.Application.Interfaces
{
    public interface IFuelStationService
    {
        Task<List<FuelStationDto>> GetFuelStationsByLocationAsync(string location, CancellationToken cancellationToken = default);
        Task<List<FuelStationDto>> GetFuelStationsByCompanyIdAsync(int fuelCompanyId, CancellationToken cancellationToken = default);
        Task<FuelStationDetailsDto?> GetFuelStationDetailsByIdAsync(int fuelStationId, CancellationToken cancellationToken = default);
        Task<FuelStationDto> CreateFuelStationAsync(CreateFuelStationDto dto, CancellationToken cancellationToken = default);
        Task UpdateFuelStationAsync(int id, CreateFuelStationDto dto, CancellationToken cancellationToken = default);
        Task DeleteFuelStationAsync(int id, CancellationToken cancellationToken = default);
    }
}
