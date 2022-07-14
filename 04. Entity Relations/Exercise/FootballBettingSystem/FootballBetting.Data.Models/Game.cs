namespace FootballBetting.Data.Models
{
    using System;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    [Table("Games", Schema = "team")]
    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();

            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }


        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        [Required]
        [MaxLength(1000)]
        public byte HomeTeamGoals { get; set; }

        // Not Required
        [Column(TypeName = "DECIMAL(5, 2)")]
        public decimal HomeTeamBetBetRate { get; set; }


        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        [Required]
        [MaxLength(1000)]
        public byte AwayTeamGoals { get; set; }

        // Not Required
        [Column(TypeName = "DECIMAL(5, 2)")]
        public decimal AwayTeamBetRate { get; set; }


        // Not Required
        [Column(TypeName = "DECIMAL(5, 2)")]
        public decimal DrawBetBetRate { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GaneResultMaxLength)]
        public string Result { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
