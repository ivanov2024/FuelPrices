using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class FuelStation
    {
        public int Id { get; set; }

        public int FuelCompanyId { get; set; }
        public FuelCompany FuelCompany { get; set; } = null!;

        public ICollection<FuelPrice> FuelPrices { get; set; } = new HashSet<FuelPrice>();

        public ICollection<StationEmployee> StationEmployees { get; set; } = new HashSet<StationEmployee>();

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = null!;
    }
}
