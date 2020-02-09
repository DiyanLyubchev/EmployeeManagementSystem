using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemData.Models.Employees;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeManagementSystemContext context;

        public EmployeeService(EmployeeManagementSystemContext context)
        {
            this.context = context;
        }


        public async Task<EmployeeDto> GetEmployeeAsync(int employeeId)
        {
            var employee = await this.context.Employees
                .Include(company => company.Company)
                .Include(office => office.Office)
                .ThenInclude(city => city.City)
                .ThenInclude(country => country.Country)
                .FirstAsync(empId => empId.Id == employeeId);


            return new EmployeeDto
            {
                Id = employeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ExperienceEmployeeId = employee.ExperienceEmployeeId,
                VacationDays = employee.VacationDays,
                Salary = employee.Salary,
                CompanyId = employee.CompanyId,
                CompanyName = employee.Company.Name,
                CountryId = employee.Office.City.CountryId,
                CityName = employee.Office.City.Name,
                CountryName = employee.Office.City.Country.Name,
            };
        }

        public async Task<bool> AddAsync(EmployeeDto dto)
        {
            ValidationEmployee.ValidationEmployeeFirstNameLength(dto.FirstName);
            ValidationEmployee.ValidationEmployeeLastNameLength(dto.LastName);
            ValidationEmployee.ValidationEmployeeExperienceEmployeeId(dto.ExperienceEmployeeId);
            ValidationEmployee.ValidationEmployeeOfficeId(dto.OfficeId);
            ValidationEmployee.ValidationEmployeeCompanyId(dto.CompanyId);

            var office = await this.context.Offices
                .Where(officeId => officeId.Id == dto.OfficeId)
                .SingleOrDefaultAsync();

            ValidatorOffice.ValidatorOffices(office);

            var company = await this.context.Companies
                .Where(companyId => companyId.Id == dto.CompanyId)
                .SingleOrDefaultAsync();

            ValidatorCompany.ValidateCompanyIfNotExistExist(company);

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                VacationDays = dto.VacationDays,
                CompanyId = dto.CompanyId,
                Company = company,
                ExperienceEmployeeId = dto.ExperienceEmployeeId,
                Office = office,
                OfficeId = dto.OfficeId,
                Salary = dto.Salary,
                StartingDate = DateTime.Now
            };

            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return await this.context.Employees.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ExperienceEmployeeId = employee.ExperienceEmployeeId,
                VacationDays = employee.VacationDays,
                StartingDate = employee.StartingDate,
                Salary = employee.Salary,
                CompanyId = employee.CompanyId,
                CompanyName = employee.Company.Name,
                OfficeId = employee.OfficeId,
                CityName = employee.Office.City.Name,
                CountryName = employee.Office.City.Country.Name,
                CountryId = employee.Office.City.Country.Id
            }).ToListAsync();
        }


        public async Task EditAsync(EmployeeDto dto)
        {
            ValidationEmployee.ValidationEmployeeFirstNameLength(dto.FirstName);
            ValidationEmployee.ValidationEmployeeLastNameLength(dto.LastName);

            var employee = await this.context.Employees.FindAsync(dto.Id);

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.ExperienceEmployeeId = dto.ExperienceEmployeeId;
            employee.Salary = dto.Salary;
            employee.VacationDays = dto.VacationDays;


            await this.context.SaveChangesAsync();

        }
    }
}
