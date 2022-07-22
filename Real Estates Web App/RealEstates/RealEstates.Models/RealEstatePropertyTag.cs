using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Models
{
    public class RealEstatePropertyTag
    {
        [ForeignKey(nameof(RealEstateProperty))]
        public int RealEstatePropertyId { get; set; }
        public virtual RealEstateProperty RealEstateProperty { get; set; }


        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
