using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using EmployeeManagementSystemData.Models.Companies;

namespace EmployeeManagementSystemDataService.Companies
{
    public class OfficeService : IOfficeService
    {
        private readonly EmployeeManagementSystemContext context;

        public OfficeService(EmployeeManagementSystemContext context)
        {
            this.context = context;
        }

        public async Task<OfficeDto> GetAsync(int id)
        {
            var office = await this.context.Offices
                .Include(c => c.City).FirstAsync(office => office.Id == id);

            ValidatorOffice.ValidatorOffices(office);

            return new OfficeDto
            {
                Id = office.Id,
                Street = office.Street,
                StreetNumber = office.StreetNumber,
                CityId = office.CityId,
                CountryId = office.City.CountryId,
                CompanyId = office.CompanyId
            };
        }

        public async Task<IEnumerable<OfficeDto>> GetByCompanyAsync(int companyId)
        {
           var test = await this.context.Offices
                .Include(company => company.Company)
                .Where(office => office.CompanyId == companyId)
                .Select(office => new OfficeDto
                {
                    Id = office.Id,
                    Street = office.Street,
                    StreetNumber = office.StreetNumber,
                    CityId = office.CityId,
                    CityName = office.City.Name,
                    CompanyName = office.Company.Name,
                    CompanyId = office.CompanyId,
                }).ToListAsync();

            var stop = 9;

            return test;
        }

        public async Task<IEnumerable<OfficeDto>> GetAllAsync()
        {
            return await this.context.Offices.Select(office => new OfficeDto
            {
                Id = office.Id,
                Street = office.Street,
                StreetNumber = office.StreetNumber,
                CityId = office.CityId,
                CompanyId = office.CompanyId,
                CompanyName = office.Company.Name,
                CountryName = office.City.Country.Name,
                CityName = office.City.Name
            }).ToListAsync();
        }

        public async Task<bool> AddAsync(OfficeDto dto)
        {
            ValidatorOffice.ValidatorAddOfficeIfDtoIsNull(dto);

            var office = new Office
            {
                Street = dto.Street,
                StreetNumber = dto.StreetNumber,
                CityId = dto.CityId,
                CompanyId = dto.CompanyId,
            };

            await this.context.Offices.AddAsync(office);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task EditAsync(OfficeDto dto)
        {
            ValidatorOffice.ValidatorAddOfficeIfIdNotExist(dto.Id);

            var office = await this.context.Offices.FindAsync(dto.Id);
            var addres = ValidatorOffice.ValidatorForUpdateOfficeStreet(dto);
            var number = ValidatorOffice.ValidatorForUpdateOfficeStreetNumber(dto);

            if (addres)
            {
                office.Street = dto.Street;
            }

            if (number)
            {
                office.StreetNumber = dto.StreetNumber;
            }

            office.CompanyId = dto.CompanyId;
            office.CityId = dto.CityId;

            await this.context.SaveChangesAsync();
        }
    }
}
