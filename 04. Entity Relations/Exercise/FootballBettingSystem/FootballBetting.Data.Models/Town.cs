namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Towns", Schema = "team")]
    public class Town
    {
        public Town()
        {
            this.Teams = new HashSet<Team>();
        }


        [Key]
        public int TownId { get; set; }


        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }


        [Required]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }


        // In one town have many teams
        public virtual ICollection<Team> Teams { get; set; }
    }
}
