using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetByCountryAsync(int countryId);
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<bool> AddCityAsync(CityDto dto);
        Task<IEnumerable<CityDto>> GetAllByCountryIdAsync(int id);
    }
}