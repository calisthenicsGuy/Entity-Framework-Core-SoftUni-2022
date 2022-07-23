using RealEstates.Services.Models.Districts;
using System.Collections.Generic;

namespace RealEstates.Services.Contracts
{
    public interface IDistrictService
    {
        IEnumerable<DistrictViewDto> GetTopDistrictsByAveragePrice(int count = 10);

        IEnumerable<DistrictViewDto> GetTopDistrictsByNumberOfProperties(int count = 10);

    }
}
