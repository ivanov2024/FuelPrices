using FuelCompany;
using FuelType;
using System.ComponentModel.DataAnnotations;

namespace FuelStation
{
    public class FuelStation
    {
        public int Id { get; set; }

        [Required]
        public int FuelCompanyId { get; set; }
        [Required]
        public FuelCompany FuelCompany { get; set; } = null!;

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = null!;
    }
}
