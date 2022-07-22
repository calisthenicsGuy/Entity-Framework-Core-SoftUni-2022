using System.Collections.Generic;

namespace RealEstates.Services.Models.Districts
{
    public class DistrictViewDto
    {
        public string Name { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public double AveragePrice { get; set; }
        // public double AveragePrice => this.GetAveragePrice();

        public int PropertiesCount { get; set; }

        //private double GetAveragePrice()
        //{
        //    return (this.MinPrice + this.MaxPrice) / 2;
        //}
    }
}
