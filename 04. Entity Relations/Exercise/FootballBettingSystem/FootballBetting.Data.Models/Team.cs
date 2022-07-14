namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Teams", Schema = "team")]
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();

            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }


        [Key]
        public int TeamId { get; set; }


        [Required]
        [MaxLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(19, 4)")]
        public decimal Budget { get; set; }


        [Required]
        [Column(TypeName = "NCHAR(3)")]
        public string Initials { get; set; }

        // Not Required
        [MaxLength(GlobalConstants.LogoURLMaxLength)]
        public string LogoURL { get; set; }


        [Required]
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public virtual Color PrimaryKitColor { get; set; }


        [ForeignKey(nameof(SecondKitColor))]
        public int SecondKitColorId { get; set; }
        public virtual Color SecondKitColor { get; set; }


        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }


        // One Team have many players
        public virtual ICollection<Player> Players { get; set; }

        // One team have many home games
        [InverseProperty(nameof(Game.HomeTeam))]
        public virtual ICollection<Game> HomeGames { get; set; }

        // One team have many away games
        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; }
    }
}
