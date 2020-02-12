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

        public async Task<IEnumerable<CompanyDto>> SearchAsync(SearchDto dto)
        {

            var listCompanies = await this.context.Companies
               .Where(name => name.Name.ToLower().Contains(dto.Data
               .ToLower()) && name.IsDeleted == false)
               .Select(company => new CompanyDto 
               {
                   Id = company.Id,
                   Name = company.Name , 
                   CreationDate =company.CreationDate
               })
               .ToListAsync();

            return listCompanies;
        }
    }
}
