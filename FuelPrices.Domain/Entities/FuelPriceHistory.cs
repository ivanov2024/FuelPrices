using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelPriceHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FuelPriceId { get; set; }
        [Required]
        public FuelPrice FuelPrice { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "999.99")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ChangedAt { get; set; }
    }
}
