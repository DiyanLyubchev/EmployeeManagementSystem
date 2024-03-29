﻿using EmployeeManagementSystemData.Models.Employees;
using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Contracts
{
    public interface IEmployeeService
    {

        Task<bool> AddAsync(EmployeeDto dto);

        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto> GetEmployeeAsync(int id);

        Task EditAsync(EmployeeDto dto);

        Task DeleteEmployeeAsync(EmployeeDto dto);

        Task<StringBuilder> ExportEmployees();
    }
}