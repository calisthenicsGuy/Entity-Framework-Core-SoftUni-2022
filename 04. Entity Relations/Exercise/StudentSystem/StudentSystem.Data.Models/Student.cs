namespace StudentSystem.Data.Models
{
    using System;
    using StudentSystem.Data.Common;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
            this.StudentCourses = new HashSet<StudentCourse>();
        }


        [Key]
        public int StudentId { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudentNameMaxLength)]
        public string Name { get; set; }

        [Column(TypeName = "CHAR")]
        [MaxLength(GlobalConstants.StudentPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        // In Sql Server - Bool -> BIT
        // Not Required
        public bool RegisteredOn { get; set; }

        [InverseProperty(nameof(HomeworkSubmission.Student))]
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }


        [InverseProperty(nameof(StudentCourse.Student))]
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
