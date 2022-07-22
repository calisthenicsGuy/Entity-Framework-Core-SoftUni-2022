using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class PropertyService : IPropertyService
    {
        private RealEstateDbContext dbContext;
        private IMapper mapper;

        public PropertyService(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PropertyService(RealEstateDbContext dbContext, IMapper mapper)
            : this (dbContext)
        {
            this.mapper = mapper;
        }

        public void Create
            (string district, int square, int price, int? year, 
             string buildingType, string propertyType, int? floor, int? totalaNumberOfFloor)
        {
            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }

            RealEstateProperty property = SetProperties(square, price, year, floor, totalaNumberOfFloor);

            property.District = SetDistrict(district);
            property.BuildingType = SetBuildingType(buildingType);
            property.PropertyType = SetPropertyType(propertyType);

            dbContext.RealEstateProperties.Add(property);
            dbContext.SaveChanges();

            this.UpdateTags(property.Id);
        }

        public void UpdateTags(int propertyId)
        {
            RealEstateProperty property = this.dbContext.RealEstateProperties.FirstOrDefault(p => p.Id == propertyId);
            property.Tags.Clear();
            if (property.Year.HasValue && property.Year <= 1990)
            {
                AddRealEstatePropertyTag("OldBuilding", property);
            }
            if (property.Square >= 120)
            {
                AddRealEstatePropertyTag("HugeApartment", property);
            }
            if (property.Year >= 2018 && property.TotalNumbersOfFloors > 5)
            {
                AddRealEstatePropertyTag("HasParking", property);
            }
            if (property.Floor == property.TotalNumbersOfFloors)
            {
                AddRealEstatePropertyTag("LastFloorApartment", property);
            }
            if ((property.Price / property.Square) < 800)
            {
                AddRealEstatePropertyTag("CheapApartment", property);
            }
            if ((property.Price / property.Square) > 2000)
            {
                AddRealEstatePropertyTag("ExpensiveApartment", property);
            }

            this.dbContext.SaveChanges();
        }

        public IEnumerable<PropertyViewDto> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return this.dbContext.RealEstateProperties
                .Where(p => (p.Year >= minYear && p.Year <= maxYear) && (p.Square >= minSize && p.Square <= maxSize))
                .ProjectTo<PropertyViewDto>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public IEnumerable<PropertyViewDto> SearchByPrice(int minPrice, int maxPrice)
        {
            return this.dbContext.RealEstateProperties
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ProjectTo<PropertyViewDto>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .ToList();
        }
        

        // some private usefull methods
        private RealEstateProperty SetProperties(int square, int price, int? year, int? floor, int? totalaNumberOfFloor)
        {
            RealEstateProperty property = new RealEstateProperty()
            {
                Square = square,
                Price = price,
                Year = year < 1800 ? null : year,
                Floor = floor <= 0 ? null : floor,
                TotalNumbersOfFloors = totalaNumberOfFloor <= 0 ? null : totalaNumberOfFloor,
            };

            return property;
        }
        private District SetDistrict(string district)
        {
            District givenDistrict = this.dbContext.Districts.FirstOrDefault(d => d.Name.Trim() == district.Trim());

            if (givenDistrict == null)
            {
                givenDistrict = new District() { Name = district };
            }

            return givenDistrict;
        }
        private BuildingType SetBuildingType(string buildingType)
        {
            BuildingType givenBuildingType = this.dbContext.BuildingTypes
                .FirstOrDefault(b => b.Name.Trim() == buildingType.Trim());

            if (givenBuildingType == null)
            {
                givenBuildingType = new BuildingType() { Name = buildingType };
            }

            return givenBuildingType;
        }
        private PropertyType SetPropertyType(string propertyType)
        {
            PropertyType givenPropertyType = this.dbContext.PropertyTypes
                .FirstOrDefault(p => p.Name.Trim() == propertyType.Trim());

            if (givenPropertyType == null)
            {
                givenPropertyType = new PropertyType() { Name = propertyType };
            }

            return givenPropertyType;
        }

        private Tag GetOrCreateTag(string tag)
        {
            var tagEntity = this.dbContext.Tags.FirstOrDefault(t => t.Name.Trim() == tag.Trim());

            if (tagEntity == null)
            {
                tagEntity = new Tag() { Name = tag };
            }

            return tagEntity;
        }
        private void AddRealEstatePropertyTag(string tag, RealEstateProperty property)
        {
            property.Tags.Add(new RealEstatePropertyTag()
            {
                Tag = this.GetOrCreateTag(tag)
            });
        }
    }
}