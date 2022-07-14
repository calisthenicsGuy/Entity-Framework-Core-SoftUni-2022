namespace FootballBetting.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // Mapping Class -> One
    [Table("PlayerStatistics", Schema = "team")]
    public class PlayerStatistic
    {

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }


        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }


        [Required]
        public byte ScoredGoals { get; set; }


        [Required]
        public byte MinutesPlayed { get; set; }
    }
}
