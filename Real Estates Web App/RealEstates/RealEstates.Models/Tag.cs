using RealEstates.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.TagNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
