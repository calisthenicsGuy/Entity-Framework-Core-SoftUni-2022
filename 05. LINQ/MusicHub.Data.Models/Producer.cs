namespace MusicHub.Data.Models
{
    using MusicHub.Data.Common;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Producer
    {

        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ProducerNameAndPseudonymMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.ProducerNameAndPseudonymMaxLength)]
        public string Pseudonym { get; set; }

        [Column(TypeName = "CHAR(10)")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
