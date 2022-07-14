namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Countries", Schema = "team")]
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }


        [Key]
        public int CountryId { get; set; }


        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; }


        [InverseProperty(nameof(Town.Name))]
        public ICollection<Town> Towns { get; set; }
    }
}
