using System.ComponentModel.DataAnnotations;

namespace FuelCompany
{
    public class FuelCompany
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string Information { get; set; } = null!;

        public int NumberOfStations { get; set; }

        public virtual ICollection<FuelStation> FuelStations { get; set } =
            new HashSet<FuelStation>();
    }
}
