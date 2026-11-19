using FuelPrices.Domain.Entities;
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

        [Required]
        public FuelPrice FuelPrice { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = null!;
    }
}
