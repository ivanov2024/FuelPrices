using FuelPrices.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelStation
    {
        public int Id { get; set; }

        [Required]
        public int FuelCompanyId { get; set; }
        [Required]
        public FuelCompany FuelCompany { get; set; } = null!;

        public ICollection<FuelPrice> FuelPrices { get; set; }
        = new HashSet<FuelPrice>();

        public ICollection<StationEmployee> Employees { get; set; }
            = new HashSet<StationEmployee>();

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = null!;
    }
}
