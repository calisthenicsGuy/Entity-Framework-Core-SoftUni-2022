using System.IO;
using System.Linq;
using Newtonsoft.Json;
using RealEstates.Data;
using RealEstates.Services;
using System.Collections.Generic;
using RealEstates.Services.Contracts;
using AutoMapper;
using RealEstates.Services.MappingConfiguration;

namespace RealEstates.Importer
{
    public class Program
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            mapper = new Mapper(new MapperConfiguration(config => 
            {
                config.AddProfile<RealEstateProfile>();
            }));

            RealEstateDbContext dbContext = new RealEstateDbContext();
            IPropertyService propertyService = new PropertyService(dbContext, mapper);
            
            //string json = File.ReadAllText(@"..\..\..\imot.bg-raw-data-2021-03-18.json");
            //ICollection<JsonProperty> properties = JsonConvert.DeserializeObject<List<JsonProperty>>(json);

            //foreach (var property in properties)
            //{
            //    propertyService.Create
            //        (property.District, property.Size, property.Price, property.Year, 
            //         property.BuildingType, property.Type, property.Floor, property.ToatlFloors);
            //}


            foreach (var property in propertyService.SearchByPrice(0, 20000))
            {
                System.Console.WriteLine($"{property.District} => {property.Price}");
            }
        }
    }
}
