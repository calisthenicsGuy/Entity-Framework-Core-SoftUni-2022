using AutoMapper;
using RealEstates.Models;
using RealEstates.Services.Models.Districts;
using RealEstates.Services.Models.Properties;
using System.Linq;

namespace RealEstates.Services.MappingConfiguration
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            this.CreateMap<RealEstateProperty, PropertyViewDto>()
                .ForMember(d => d.District, mo => mo.MapFrom(s => s.District.Name))
                .ForMember(d => d.PropertyType, mo => mo.MapFrom(s => s.PropertyType.Name))
                .ForMember(d => d.BuildingType, mo => mo.MapFrom(s => s.BuildingType.Name))
                .ForMember(d => d.Floor, 
                    mo => mo.MapFrom(s => $"{(s.Floor ?? 0).ToString()}/{(s.TotalNumbersOfFloors ?? 0).ToString()}"));

            this.CreateMap<District, DistrictViewDto>()
                .ForMember(d => d.MinPrice,
                    mo => mo.MapFrom(s => s.RealEstateProperty.Min(p => p.Price)))
                .ForMember(d => d.MaxPrice,
                    mo => mo.MapFrom(s => s.RealEstateProperty.Max(p => p.Price)))
                .ForMember(d => d.AveragePrice, 
                    mo => mo.MapFrom(s => s.RealEstateProperty.Average(p => p.Price)))
                .ForMember(d => d.PropertiesCount, mo => mo.MapFrom(s => s.RealEstateProperty.Count));
        }
    }
}
