namespace FootballBetting.Data.Models
{
    using System;
    using FootballBetting.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bets", Schema = "team")]
    public class Bet
    {
        [Key]
        public int BetId { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(19, 4)")]
        public decimal Amount { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }


        [Required]
        // Enumeration in Sql Server - Integer
        public Prediction Prediction { get; set; }


        [Required]
        public DateTime DateTime { get; set; }


        // Bet can be placed by only one User and One User can place Many Bets - One-To-Many Relation
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
