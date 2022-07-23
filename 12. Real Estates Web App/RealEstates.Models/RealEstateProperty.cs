using RealEstates.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Models
{
    public class RealEstateProperty
    {
        public RealEstateProperty()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(GlobalConstants.RealEstatePropertyNameMaxLength)]
        public decimal Square { get; set; }

        public int? Floor { get; set; }

        public int? TotalNumbersOfFloors { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public int? Year { get; set; }

        [Required]
        [ForeignKey(nameof(PropertyType))]
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        [Required]
        [ForeignKey(nameof(BuildingType))]
        public int BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
