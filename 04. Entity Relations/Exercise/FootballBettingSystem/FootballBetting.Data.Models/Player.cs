namespace FootballBetting.Data.Models
{
    using FootballBetting.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Players", Schema = "team")]
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }


        [Key]
        public int PlayerId { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsInjured { get; set; }


        [Required]
        [MaxLength(GlobalConstants.PlayerNameMaxLength)]
        public string Name { get; set; }


        [Required]
        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public Position Position { get; set; } // Navigation property to particular Position


        public byte SquadNumber { get; set; }


        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public Team Team { get; set; }


        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
