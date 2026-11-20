using FuelPrices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelPrices.Infrastructure.Data.Configurations
{
    internal class FuelCompanyConfiguration : IEntityTypeConfiguration<FuelCompany>
    {
        public void Configure(EntityTypeBuilder<FuelCompany> builder)
        {
            builder.HasKey(fc => fc.Id);

            builder.Property(fc => fc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(fc => fc.Information)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasMany(fc => fc.FuelStations)
                .WithOne(fs => fs.FuelCompany)
                .HasForeignKey(fs => fs.FuelCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
