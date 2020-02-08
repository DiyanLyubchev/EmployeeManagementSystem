using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public class EmployeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public int ExperienceEmployee { get; set; }

        public string CompanyName { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int CityId { get; set; }

        public int CompanyId { get; set; }


        public int? OfficeId { get; set; }

        public IEnumerable<CompanyViewModel> AllCompanies { get; set; }
        public IEnumerable<CountryViewModel> AllCountries { get; set; }
        public IEnumerable<CityViewModel> CitiesByCountry { get; set; }

        public IEnumerable<OfficeViewModel> AllOfficies { get; set; }
    }
}
