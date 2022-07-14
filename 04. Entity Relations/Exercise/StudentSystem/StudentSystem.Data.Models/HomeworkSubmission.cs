namespace StudentSystem.Data.Models
{
    using Enums;
    using System;
    using StudentSystem.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HomeworkSubmission
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.HomeworkContentMaxLength)]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
