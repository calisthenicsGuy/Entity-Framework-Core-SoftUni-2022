namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Colors", Schema = "team")]
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondKitTeam = new HashSet<Team>();
        }


        [Key]
        public int ColorId { get; set; }


        [Required]
        [MaxLength(GlobalConstants.ColorNameMaxLength)]
        public string Name { get; set; }


        // Many PrimaryKitTeams
        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        // Many SecondKitTeam
        [InverseProperty(nameof(Team.SecondKitColor))]
        public virtual ICollection<Team> SecondKitTeam { get; set; }

    }
}
