using System;

namespace EmployeeManagementSystemDataService.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime StartingDate { get; set; }

        public int VacationDays { get; set; } 

        public int ExperienceEmployeeId { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string CompanyName { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public int? OfficeId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
