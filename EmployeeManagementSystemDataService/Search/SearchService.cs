using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Search
{
    public class SearchService : ISearchService
    {
        private readonly EmployeeManagementSystemContext context;

        public SearchService(EmployeeManagementSystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CompanyDto>> SearchCompanyAsync(SearchDto dto)
        {

            var listCompanies = await this.context.Companies
               .Where(name => name.Name.ToLower().Contains(dto.Data
               .ToLower()) && name.IsDeleted == false)
               .Select(company => new CompanyDto
               {
                   Id = company.Id,
                   Name = company.Name,
                   CreationDate = company.CreationDate,
                   CountEmployees = company.Employees.Count(),
                   CountOffices = company.Offices.Count()
               })
               .ToListAsync();

            return listCompanies;
        }

        public async Task<IEnumerable<OfficeDto>> SearchOfficeAsync(SearchDto dto)
        {
            var listOffices = await this.context.Offices
               .Where(name => name.Company.Name.ToLower().Contains(dto.Data
               .ToLower()) && name.IsDeleted == false)
               .Select(office => new OfficeDto
               {
                   Id = office.Id,
                   CityName = office.City.Name,
                   Street = office.Street,
                   StreetNumber = office.StreetNumber,
                   CompanyName = office.Company.Name,
                   CountryName = office.City.Country.Name
               })
               .ToListAsync();

            return listOffices;
        }
        public async Task<IEnumerable<EmployeeDto>> SearchEmployeeAsync(SearchDto dto)
        {
            var listEmployee = await this.context.Employees
               .Where(name => name.FirstName.ToLower().Contains(dto.Data
               .ToLower()) && name.IsDeleted == false)
               .Select(employee => new EmployeeDto
               {
                   Id = employee.Id,
                   FirstName = employee.FirstName,
                   LastName = employee.LastName,
                   ExperienceEmployeeId = employee.ExperienceEmployeeId,
                   VacationDays = employee.VacationDays,
                   StartingDate = employee.StartingDate,
                   Salary = employee.Salary,
                   IsDeleted = employee.IsDeleted,
                   CompanyId = employee.CompanyId,
                   CompanyName = employee.Company.Name,
                   OfficeIsDeleted = employee.Office.IsDeleted,
                   CompanyIsDeleted = employee.Company.IsDeleted,
                   OfficeId = employee.OfficeId,
                   CityName = employee.Office.City.Name,
                   CountryName = employee.Office.City.Country.Name,
                   CountryId = employee.Office.City.Country.Id
               })
               .ToListAsync();

            return listEmployee;
        }
    }
}
