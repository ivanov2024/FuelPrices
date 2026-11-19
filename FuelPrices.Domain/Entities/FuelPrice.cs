using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelPrices.Domain.Entities
{
    public class FuelPrice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1.00, 999.00, ErrorMessage = "Price must be between 1.00 and 999.00")]
        public decimal Price { get; set; }

        [Required]
        public int FuelStationId { get; set; }
        [Required]
        public FuelStation FuelStation { get; set; } = null!;
    }
}
