using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelPrices.Domain.Entities
{
    public class StationEmployee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string FullName { get; set; } = null!;

        [Required]
        public int StationId { get; set; }
        [Required]
        public FuelStation Station { get; set; } = null!;
    }
}
