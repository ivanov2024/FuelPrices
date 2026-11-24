using FuelPrices.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Application.DTOs.Prices
{
    public class CreateFuelPriceDto
    {
        [Range(typeof(decimal), "0.01", "999.99")]
        public decimal Price { get; set; }

        [EnumDataType(typeof(FuelType))]
        public FuelType FuelType { get; set; }

        public int FuelStationId { get; set; }
    }
}
