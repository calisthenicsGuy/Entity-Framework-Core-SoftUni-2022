namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Positions", Schema = "team")]
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }


        [Key]
        public int PositionId { get; set; }


        [Required]
        [MaxLength(GlobalConstants.PositionNameMaxLength)]
        public string Name { get; set; }


        // One player play on one position, but in one position play many players - Many-To-One Relation
        // Collection of all players that play in current position
        public ICollection<Player> Players { get; set; }
    }
}
