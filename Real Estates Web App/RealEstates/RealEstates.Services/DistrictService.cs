using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models.Districts;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        private RealEstateDbContext dbContext;
        private IMapper mapper;

        public DistrictService(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DistrictService(RealEstateDbContext dbContext, IMapper mapper)
            : this(dbContext)
        {
            this.mapper = mapper;
        }
        
        public IEnumerable<DistrictViewDto> GetTopDistrictsByAveragePrice(int count = 10)
        {
            return this.dbContext.Districts
                .ProjectTo<DistrictViewDto>(this.mapper.ConfigurationProvider)
                .OrderBy(d => d.AveragePrice)
                .Take(count)
                .ToList();
        }

        public IEnumerable<DistrictViewDto> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            return this.dbContext.Districts
                .ProjectTo<DistrictViewDto>(this.mapper.ConfigurationProvider)
                .OrderByDescending(d => d.PropertiesCount)
                .Take(count)
                .OrderBy(d => d.PropertiesCount)
                .ToList();
        }
    }
}
