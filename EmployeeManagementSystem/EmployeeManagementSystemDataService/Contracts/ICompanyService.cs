using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface ICompanyService
    {
        Task<bool> AddAsync(CompanyDto dto);
        Task EditAsync(CompanyDto dto);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetAsync(int id);
    }
}