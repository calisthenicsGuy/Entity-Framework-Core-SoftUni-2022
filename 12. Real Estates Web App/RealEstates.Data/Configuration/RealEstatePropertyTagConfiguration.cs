using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.Configuration
{
    public class RealEstatePropertyTagConfiguration : IEntityTypeConfiguration<RealEstatePropertyTag>
    {
        public void Configure(EntityTypeBuilder<RealEstatePropertyTag> modelBuilder)
        {
            modelBuilder
                .HasKey(ps => new { ps.RealEstatePropertyId, ps.TagId });
        }
    }
}
