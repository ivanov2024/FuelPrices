using FuelPrices.Application.DTOs.Prices;

namespace FuelPrices.Application.Interfaces
{
    public interface IFuelPriceService
    {
        Task<List<FuelPriceDto>> GetFuelPriceAsync(int stationId, CancellationToken cancellationToken = default);
        Task<List<FuelPriceHistoryDto>> GetFuelPriceHistoryAsync(int fuelPriceId, CancellationToken cancellationToken = default);
        Task UpdateFuelPriceAsync(UpdateFuelPriceDto dto, CancellationToken cancellationToken = default);
    }
}
