namespace StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    // Mapping Table
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
