using EmployeeManagementSystemData.Models.Employees;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemData.Extentions
{
    public static class SeedExperienceEmployee
    {
        public static void ExperienceEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperienceEmployee>().HasData(ExperienceLevelSeed());
        }

        private static ExperienceEmployee[] ExperienceLevelSeed() 
        {
            return new ExperienceEmployee[]
            {
                new ExperienceEmployee
                {
                     Id = 1,
                     ExperienceLevel = "Junior"
                },

                new ExperienceEmployee
                {
                     Id = 2,
                     ExperienceLevel = "Middle"
                },

                new ExperienceEmployee
                {
                     Id = 3,
                     ExperienceLevel = "Senior"
                },
            };
        }
    }
}
