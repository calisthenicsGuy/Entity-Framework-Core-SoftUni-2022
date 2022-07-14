namespace FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using FootballBetting.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users", Schema = "team")]
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }


        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(19, 4)")]
        public decimal Balance { get; set; }


        [Required]
        [MaxLength(GlobalConstants.UserNameMaxLength)]
        public string Name { get; set; }


        [Required]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }


        [Required]
        [MaxLength(GlobalConstants.UserPasswordMaxLength)]
        public string Password { get; set; }


        [Required]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        public string Username { get; set; }


        // One User can place Many Bets - One-To-Many Relation
        public ICollection<Bet> Bets { get; set; }
    }
}
