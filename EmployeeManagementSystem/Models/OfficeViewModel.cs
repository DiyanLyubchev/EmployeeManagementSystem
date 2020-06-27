using EmployeeManagementSystem.Models;
using System.Collections.Generic;

namespace EmployeeManagementSystemDataService.Models
{
    public class OfficeViewModel
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int CompanyId { get; set; }

        public IEnumerable<CompanyViewModel> AllCompanies { get; set; }
        public IEnumerable<CountryViewModel> AllCountries { get; set; }
        public IEnumerable<CityViewModel> CitiesByCountry { get; set; }
    }
}
