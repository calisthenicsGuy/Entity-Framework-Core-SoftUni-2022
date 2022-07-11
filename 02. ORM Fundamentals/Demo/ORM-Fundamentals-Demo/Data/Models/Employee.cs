using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_Fundamentals_Demo.Data.Models
{
    public class Employee
    {
        //public Employee()
        //{
        //    this.ManagedDepartments = new HashSet<Department>();
        //}

        [Key]
        public int EmployeeID { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; } // FK -> Absolute must
        public Department Department { get; set; } // Navigation property -> optional. but very usefull

        // public virtual ICollection<Department> ManagedDepartments { get; set; }
    }
}
