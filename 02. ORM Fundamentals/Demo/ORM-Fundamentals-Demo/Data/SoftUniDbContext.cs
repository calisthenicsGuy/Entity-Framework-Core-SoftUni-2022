using Microsoft.EntityFrameworkCore;
using ORM_Fundamentals_Demo.Data.Models;

namespace ORM_Fundamentals_Demo.Data
{
    public class SoftUniDbContext : DbContext
    {
        // Empty constructor - for testing cases
        public SoftUniDbContext()
        {
        }

        // Deploy -> Run DbContext (open Connection to Sql Server)
        public SoftUniDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }


        // Table Employees
        public DbSet<Employee> Employees { get; set; }

        // Table Departments
        public DbSet<Department> Departments { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Default configuration
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }
    }
}
