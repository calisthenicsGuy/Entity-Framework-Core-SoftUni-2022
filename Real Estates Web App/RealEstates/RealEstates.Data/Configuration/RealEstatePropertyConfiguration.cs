using RealEstates.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstates.Data.Configuration
{
    public class RealEstatePropertyConfiguration : IEntityTypeConfiguration<RealEstateProperty>
    {
        public void Configure(EntityTypeBuilder<RealEstateProperty> modelBuilder)
        {
            modelBuilder
                .HasOne(c => c.District)
                .WithMany(t => t.RealEstateProperty)
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(c => c.PropertyType)
                .WithMany(t => t.RealEstateProperty)
                .HasForeignKey(c => c.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(c => c.BuildingType)
                .WithMany(t => t.RealEstateProperties)
                .HasForeignKey(c => c.BuildingTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
