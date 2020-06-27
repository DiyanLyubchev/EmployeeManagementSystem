using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<bool> AddCountryAsync(CountryDto dto);
    }
}