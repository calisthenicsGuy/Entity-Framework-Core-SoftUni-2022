using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_Fundamentals_Demo.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        
        //[MaxLength(50)]
        //[ForeignKey(nameof(Employee))]
        //public int? ManagerID { get; set; } // FK
        //public Employee Employee { get; set; } // Navigation Property

        //// Navigational Property is good to be virtual (LazyLoading)
        

    }
}
