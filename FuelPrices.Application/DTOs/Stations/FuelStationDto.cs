namespace FuelPrices.Application.DTOs.Stations
{
    public class FuelStationDto
    {
        public int Id { get; set; }
        public int FuelCompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
