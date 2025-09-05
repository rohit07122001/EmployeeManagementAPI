using EmployeeManagementAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI1.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Employee> EMployees { get; set; }
    }
}







