using EmployeeManagementSystemData.Models.Employees;
using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> GetUserAsync(int userId);

        Task<bool> AddAsync(EmployeeDto dto);

        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}