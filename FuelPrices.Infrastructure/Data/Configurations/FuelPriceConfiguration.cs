using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelPrices.Infrastructure.Data.Configurations
{
    internal class FuelPriceConfiguration : IEntityTypeConfiguration<FuelPrice>
    {
        public void Configure(EntityTypeBuilder<FuelPrice> builder)
        {
            builder.HasKey(fp => fp.Id);

            builder.Property(fp => fp.Price)
                .HasPrecision(18, 2);

            builder.Property(fp => fp.LastUpdated)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(fp => new { fp.FuelStationId, fp.FuelType })
                .IsUnique();

            builder.HasOne(fp => fp.FuelStation)
                .WithMany(fs => fs.FuelPrices)
                .HasForeignKey(fp => fp.FuelStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(fp => fp.FuelPriceHistories)
                .WithOne(fph => fph.FuelPrice)
                .HasForeignKey(fph => fph.FuelPriceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
