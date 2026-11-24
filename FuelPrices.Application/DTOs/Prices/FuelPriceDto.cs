using FuelPrices.Domain.Enums;

namespace FuelPrices.Application.DTOs.Prices
{
    public class FuelPriceDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public FuelType FuelType { get; set; }
        public DateTime LastUpdated { get; set; }
        public int FuelStationId { get; set; }
    }
}