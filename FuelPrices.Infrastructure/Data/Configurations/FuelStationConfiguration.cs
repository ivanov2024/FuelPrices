using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelPrices.Infrastructure.Data.Configurations
{
    internal class FuelStationConfiguration : IEntityTypeConfiguration<FuelStation>
    {
        public void Configure(EntityTypeBuilder<FuelStation> builder)
        {
            builder.HasKey(fs => fs.Id);

            builder.Property(fs => fs.Location)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(fs => fs.FuelCompany)
                .WithMany(fc => fc.FuelStations)
                .HasForeignKey(fs => fs.FuelCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(fs => fs.FuelPrices)
                .WithOne(fp => fp.FuelStation)
                .HasForeignKey(fp => fp.FuelStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(fs => fs.StationEmployees)
                .WithOne(se => se.FuelStation)
                .HasForeignKey(se => se.FuelStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
