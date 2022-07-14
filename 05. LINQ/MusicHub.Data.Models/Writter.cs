namespace MusicHub.Data.Models
{
    using MusicHub.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Writter
    {
        public Writter()
        {
            this.Writters = new HashSet<Writter>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.WritterNameAndPseudonymMaxLength)]
        public string Name { get; set; }

        // Not Required
        [MaxLength(GlobalConstants.WritterNameAndPseudonymMaxLength)]
        public string Pseudonym { get; set; }


        public virtual ICollection<Writter> Writters { get; set; }
    }
}
