namespace MusicHub.Data.Models
{
    using MusicHub.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Performer
    {
        public Performer()
        {
            this.SongsPerformers = new HashSet<SongsPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PerformerFirstNameMaxLength)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(GlobalConstants.PerformerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        
        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongsPerformer> SongsPerformers { get; set; }

    }
}
