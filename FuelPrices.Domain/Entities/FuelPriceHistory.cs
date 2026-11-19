using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelPrices.Domain.Entities
{
    public class FuelPriceHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FuelPriceId { get; set; }
        [Required]
        public FuelPrice FuelPrice { get; set; } = null!;

        [Required]
        public DateTime ChangedAt { get; set; }
    }
}
