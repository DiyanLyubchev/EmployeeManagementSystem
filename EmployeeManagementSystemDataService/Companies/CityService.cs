using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Companies
{
    public class CityService : ICityService
    {
        private readonly EmployeeManagementSystemContext context;

        public CityService(EmployeeManagementSystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public async Task<IEnumerable<CityDto>> GetByCountryAsync(int countryId)
        {
            return await this.context.Cities
                .Where(city => city.CountryId == countryId)
                .Select(city => new CityDto
                {
                    Id = city.Id,
                    Name = city.Name,
                    CountryId = city.CountryId
                }).ToListAsync();
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            return await this.context.Cities.Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.CountryId
            }).ToListAsync();
        }


        public async Task<IEnumerable<CityDto>> GetAllByCountryIdAsync(int id)
        {
            return await this.context.Cities
                .Where(city => city.CountryId == id)
                .Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.CountryId
            }).ToListAsync();
        }


        public async Task<bool> AddCityAsync(CityDto dto)
        {
            ValidatorCity.ValidatorAddCountryIfCityNameIsNull(dto.Name);

            var city = new City
            {
                Name = dto.Name,
                CountryId = dto.Id,
            };
            await this.context.Cities.AddAsync(city);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
