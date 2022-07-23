using System.IO;
using Newtonsoft.Json;
using RealEstates.Models;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data.Configuration;
using RealEstates.Data.SqlServerConfigurations;

namespace RealEstates.Data
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {
        }

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            :base(options)
        {
        }


        public DbSet<RealEstateProperty> RealEstateProperties { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //First way:
                JsonConfigurationEntity connectionString = 
                    JsonConvert.DeserializeObject<JsonConfigurationEntity>
                    (File.ReadAllText(@"..\..\..\..\RealEstates.Data\SqlServerConfigurations\config.json"));
                optionsBuilder.UseSqlServer(connectionString.ConnectionString);

                // Second way:
                // optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RealEstatePropertyConfiguration());
            modelBuilder.ApplyConfiguration(new RealEstatePropertyTagConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
