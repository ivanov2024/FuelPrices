using FuelPrices.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelPrice
    {
        public int Id { get; set; }

        [Range(typeof(decimal), "0.01", "999.99")]
        public decimal Price { get; set; }

        public FuelType FuelType { get; set; }

        public DateTime LastUpdated { get; set; }

        public int FuelStationId { get; set; }
        public FuelStation FuelStation { get; set; } = null!;

        public ICollection<FuelPriceHistory> FuelPriceHistories { get; set; } = new HashSet<FuelPriceHistory>();
    }
}
