using RealEstates.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.RealEstateProperties = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.BuildingTypeNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> RealEstateProperties { get; set; }
    }
}
