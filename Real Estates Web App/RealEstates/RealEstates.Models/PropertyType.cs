using RealEstates.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class PropertyType
    {
        public PropertyType()
        {
            this.RealEstateProperty = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.PropertyTypeNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<RealEstateProperty> RealEstateProperty { get; set; }
    }
}
