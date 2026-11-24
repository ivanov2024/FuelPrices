using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Application.DTOs.Prices
{
    public class UpdateFuelPriceDto
    {
        public int Id { get; set; }

        [Range(typeof(decimal), "0.01", "999.99")]
        public decimal Price { get; set; }
    }
}