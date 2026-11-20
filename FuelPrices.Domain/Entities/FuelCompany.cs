using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelCompany
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string Information { get; set; } = null!;

        public ICollection<FuelStation> FuelStations { get; set; } = new HashSet<FuelStation>();
    }
}
