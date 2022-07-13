namespace Application.Configuration
{
    using Application.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets", "animals"); // Attribute - [Table("Pets", Schema = "animals")]
            builder.Property(x => x.Species)
                   .HasColumnName("Type")
                   .HasColumnType("NVARCHAR(50)");
            builder.Property(x => x.DateOfBuying)
                   .ValueGeneratedOnAddOrUpdate(); // Ignore values that we set in c# code
        }
    }
}
