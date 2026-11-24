using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelPriceHistory
    {
        public int Id { get; set; }

        public int FuelPriceId { get; set; }
        public FuelPrice FuelPrice { get; set; } = null!;

        [Range(typeof(decimal), "0.01", "999.99")]
        public decimal Price { get; set; }

        public DateTime ChangedAt { get; set; }
    }
}