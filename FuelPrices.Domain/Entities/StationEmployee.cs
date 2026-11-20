using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class StationEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int FuelStationId { get; set; }

        public FuelStation FuelStation { get; set; } = null!;
    }
}
