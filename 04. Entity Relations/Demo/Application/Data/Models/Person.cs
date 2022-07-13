namespace Application.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public Person()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public int PersonId { get; set; }


        public string EGN { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName => $"{this.Name} {this.LastName}";

        public ICollection<Pet> Pets { get; set; }
    }
}
