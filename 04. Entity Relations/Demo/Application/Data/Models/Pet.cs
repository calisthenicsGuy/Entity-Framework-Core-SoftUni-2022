namespace Application.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pets", Schema = "animals")]
    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        [StringLength(50)]
        public string Species { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Name", Order = 3, TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        public DateTime DateOfBuying { get; set; }

        [ForeignKey(nameof(PersonId))]
        public int PersonId { get; set; }
        public Person Owner { get; set; }
    }
}
