using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Companies
{
    public class CountryService : ICountryService
    {
        private readonly EmployeeManagementSystemContext context;

        public CountryService(EmployeeManagementSystemContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return await this.context.Countries.Select(country => new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
            }).ToListAsync();
        }

        public async Task<bool> AddCountryAsync(CountryDto dto)
        {
            ValidatorCountry.ValidatorAddCountryIfCountryNameIsNull(dto.Name);

            var country = new Country
            {
                Name = dto.Name,
            };

            await this.context.Countries.AddAsync(country);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
