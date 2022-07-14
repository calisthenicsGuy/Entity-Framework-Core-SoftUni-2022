namespace StudentSystem.Data.Models
{
    using StudentSystem.Data.Common;
    using StudentSystem.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ResourceNameMaxLength)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(GlobalConstants.CourseUrlMaxLength)]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
