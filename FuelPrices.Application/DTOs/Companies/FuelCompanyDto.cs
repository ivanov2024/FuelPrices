using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Application.DTOs.Companies
{
    public class FuelCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Information { get; set; } = null!;
    }
}
