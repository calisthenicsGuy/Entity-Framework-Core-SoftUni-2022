using RealEstates.Services.Models.Properties;
using System.Collections.Generic;

namespace RealEstates.Services.Contracts
{
    public interface IPropertyService
    {
        void Create
            (string district, int square, int price, int? year, 
             string buildingType, string propertyType, int? floor, int? totalaNumberOfFloor);

        void UpdateTags(int propertyId);

        IEnumerable<PropertyViewDto> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewDto> SearchByPrice(int minPrice, int maxPrice);
    }
}
