using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelPrices.Infrastructure.Data.Configurations
{
    internal class FuelPriceHistoryConfiguration : IEntityTypeConfiguration<FuelPriceHistory>
    {
        public void Configure(EntityTypeBuilder<FuelPriceHistory> builder)
        {
            builder.HasKey(fph => fph.Id);

            builder.Property(fph => fph.Price)
                .HasPrecision(18, 3);

            builder.Property(fph => fph.ChangedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(fph => fph.FuelPrice)
                .WithMany(fp => fp.FuelPriceHistories)
                .HasForeignKey(fph => fph.FuelPriceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
