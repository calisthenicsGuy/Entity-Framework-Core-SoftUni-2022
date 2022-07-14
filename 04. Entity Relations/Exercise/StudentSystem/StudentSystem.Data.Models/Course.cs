namespace StudentSystem.Data.Models
{
    using System;
    using StudentSystem.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
            this.Resources = new HashSet<Resource>();
            this.StudentCourses = new HashSet<StudentCourse>();

        }


        [Key]
        public int CourseId { get; set; }
        
        [Required]
        [MaxLength(GlobalConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        // Not Required
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        [InverseProperty(nameof(HomeworkSubmission.Course))]
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }


        [InverseProperty(nameof(Resource.Course))]
        public ICollection<Resource> Resources { get; set; }

        
        [InverseProperty(nameof(StudentCourse.Course))]
        public ICollection<StudentCourse> StudentCourses { get; set; }


    }
}
