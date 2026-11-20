using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelPrices.Infrastructure.Data.Configurations
{
    internal class StationEmployeeConfiguration : IEntityTypeConfiguration<StationEmployee>
    {
        public void Configure(EntityTypeBuilder<StationEmployee> builder)
        {
            builder.HasKey(se => se.Id);

            builder.HasOne(se => se.FuelStation)
                .WithMany(fs => fs.StationEmployees)
                .HasForeignKey(se => se.FuelStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(se => new { se.UserId, se.FuelStationId })
                .IsUnique();
        }
    }
}
