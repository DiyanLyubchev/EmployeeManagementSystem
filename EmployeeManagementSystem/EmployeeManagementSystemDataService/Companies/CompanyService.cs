using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly EmployeeManagementSystemContext context;
     

        public CompanyService(EmployeeManagementSystemContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(CompanyDto dto)
        {
            ValidatorCompany.ValidateCompanyNameIfIsNull(dto.Name);
            ValidatorCompany.ValidateCompanyCreationDateIfIsNull(dto.CreationDate);

           
            var company = new Company
            {
                Name = dto.Name,

                CreationDate = dto.CreationDate

            };

            await this.context.Companies.AddAsync(company);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await this.context.Companies.ToListAsync();
        }

        public async Task<Company> GetAsync(int id)
        {
            return await this.context.Companies.FindAsync(id);
        }

        public async Task EditAsync(CompanyDto dto)
        {
            ValidatorCompany.ValidateCompanyNameIfIsNull(dto.Name);
            ValidatorCompany.ValidateCompanyCreationDateIfIsNull(dto.CreationDate);

            var company = await this.context.Companies.FindAsync(dto.Id);
            company.Name = dto.Name;
            company.CreationDate = dto.CreationDate;

            await this.context.SaveChangesAsync();
        }
    }
}
