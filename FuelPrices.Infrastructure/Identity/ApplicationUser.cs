using FuelPrices.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public ICollection<StationEmployee> StationEmployees { get; set; } = new HashSet<StationEmployee>();
    }
}
