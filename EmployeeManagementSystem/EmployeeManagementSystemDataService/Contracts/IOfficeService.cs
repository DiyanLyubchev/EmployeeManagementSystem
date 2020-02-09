using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface IOfficeService
    {
        Task<OfficeDto> GetAsync(int id);

        Task<IEnumerable<OfficeDto>> GetAllAsync();

        Task<bool> AddAsync(OfficeDto dto);

        Task EditAsync(OfficeDto dto);

        Task<IEnumerable<OfficeDto>> GetByCompanyAsync(int companyId);

        Task DeleteAsync(OfficeDto dto);
    }
}