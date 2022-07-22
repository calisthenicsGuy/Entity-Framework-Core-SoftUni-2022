using AutoMapper;
using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Contracts;
using RealEstates.Services.MappingConfiguration;

namespace RealEstates.ConsoleApplications
{
    public class StartUp
    {
        private static IMapper mapper;

        static void Main(string[] args)
        {
            mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<RealEstateProfile>();
            }));

            RealEstateDbContext dbContext = new RealEstateDbContext();

            //IPropertyService propertyService = new PropertyService(dbContext, mapper);
            //IDistrictService districtService = new DistrictService(dbContext, mapper);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //propertyService.UpdateTags(1);
            //propertyService.UpdateTags(2);
            //propertyService.UpdateTags(3);
            //propertyService.Create("Дианабед", 120, 2000000, 2021, "EПК", "8-СТАЕН", 16, 20);



            //foreach (var district in districtService.GetTopDistrictsByAveragePrice())
            //{
            //    System.Console.WriteLine($"{district.Name} " +
            //        $"=> Price: {district.AveragePrice:f2} ({district.MinPrice}-{district.MaxPrice}) " +
            //        $"=> {district.PropertiesCount} properties");
            //}
        }
    }
}