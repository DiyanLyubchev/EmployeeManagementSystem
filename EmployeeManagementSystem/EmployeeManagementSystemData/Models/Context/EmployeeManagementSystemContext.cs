using EmployeeManagementSystemData.Extentions;
using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemData.Models.Employees;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemData.Models.Context
{
    public class EmployeeManagementSystemContext : IdentityDbContext<User>
    {
        public EmployeeManagementSystemContext()
        {
        }
        public EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options)
          : base(options)
        {
        }
            
        public DbSet<Employee> Employees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<ExperienceEmployee> ExperienceEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EmployeeRoles();
            modelBuilder.ExperienceEmployee();
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            base.OnModelCreating(modelBuilder);
        }
    }
}
