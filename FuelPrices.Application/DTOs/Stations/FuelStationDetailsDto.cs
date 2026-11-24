using FuelPrices.Application.DTOs.Prices;

namespace FuelPrices.Application.DTOs.Stations
{
    public class FuelStationDetailsDto
    {
        public int Id { get; set; }
        public int FuelCompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public List<FuelPriceDto> Prices { get; set; } = new();
    }
}
