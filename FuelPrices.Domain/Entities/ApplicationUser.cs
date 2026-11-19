using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FuelPrices.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        public bool IsDeleted { get; set; } = false!;
    }
}
