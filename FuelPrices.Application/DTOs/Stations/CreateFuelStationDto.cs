using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Application.DTOs.Stations
{
    public class CreateFuelStationDto
    {
        [Required]
        public int FuelCompanyId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Location { get; set; } = null!;
    }
}
