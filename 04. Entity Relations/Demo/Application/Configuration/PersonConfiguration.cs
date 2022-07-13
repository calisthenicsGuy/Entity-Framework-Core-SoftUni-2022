namespace Application.Configuration
{
    using Application.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => new { x.PersonId, x.EGN });
            builder.Property(x => x.Name)
                   .IsRequired() // NOT NULL
                   .HasMaxLength(50); // Max Length - 50
            builder.Property(x => x.LastName)
                   .IsRequired() // NOT NULL
                   .HasMaxLength(50); // Max Length - 50
            builder.Ignore(x => x.FullName); // Ignore the property - do not add as column in databases
        }
    }
}
