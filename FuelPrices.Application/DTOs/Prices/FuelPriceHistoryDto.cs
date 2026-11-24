namespace FuelPrices.Application.DTOs.Prices
{
    public class FuelPriceHistoryDto
    {
        public int Id { get; set; }
        public int FuelPriceId { get; set; }
        public decimal Price { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}