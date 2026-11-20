using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class StationEmployee
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        public int FuelStationId { get; set; }
        public FuelStation FuelStation { get; set; } = null!;
    }
}
