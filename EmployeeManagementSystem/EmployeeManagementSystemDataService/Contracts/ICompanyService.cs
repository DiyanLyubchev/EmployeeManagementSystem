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
        Task<IEnumerable<CompanyDto>> GetAllAsync();

        Task<CompanyDto> GetAsync(int id);

        Task DeleteAsync(CompanyDto dto);
        
    }
}