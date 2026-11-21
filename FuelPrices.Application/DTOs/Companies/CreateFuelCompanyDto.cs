using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Application.DTOs.Companies
{
    public class CreateFuelCompanyDto
    {
        //Symbolic minimum length
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        //Symbolic minimum length
        [Required]
        [StringLength(300, MinimumLength = 1)]
        public string Information { get; set; } = null!;
    }
}
