using RealEstates.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class District
    {
        public District()
        {
            this.RealEstateProperty = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.DistrictNameMaxLength)]
        public string Name { get; set; }
        public virtual ICollection<RealEstateProperty> RealEstateProperty { get; set; }
    }
}
