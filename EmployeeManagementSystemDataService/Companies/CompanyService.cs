﻿using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly EmployeeManagementSystemContext context;

        private const int existCompany = 1;
        public CompanyService(EmployeeManagementSystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(CompanyDto dto)
        {
            ValidatorCompany.ValidateCompanyNameIfIsNull(dto.Name);

            var company = await this.context.Companies
                .Include(office => office.Offices)
                .FirstOrDefaultAsync(name => name.Name == dto.Name && name.IsDeleted == false);

            var validate = ValidatorCompany.ValidateCompanyIfExist(company);

            var countCompany = await this.context.Companies
                .Where(name => name.Name == dto.Name && name.IsDeleted == false)
                .CountAsync();

            if (validate || countCompany < existCompany)
            {
                var newCompany = new Company
                {
                    Name = dto.Name,
                    CreationDate = dto.CreationDate
                };
                await this.context.Companies.AddAsync(newCompany);
                await this.context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            return await this.context.Companies
                .Where(isDeleted => isDeleted.IsDeleted == false)
                .Select(company => new CompanyDto
                {
                    Id = company.Id,
                    Name = company.Name,
                    CreationDate = company.CreationDate,
                    IsDeleted = company.IsDeleted,
                    CountEmployees = company.Employees.Count(),
                    CountOffices = company.Offices.Count()

                }).ToListAsync();
        }

        public async Task<CompanyDto> GetAsync(int id)
        {
            return await this.context.Companies
                .Where(comapanyId => comapanyId.Id == id && comapanyId.IsDeleted == false)
                .Select(company => new CompanyDto
                {
                    Id = company.Id,
                    CreationDate = company.CreationDate,
                    Name = company.Name,
                    IsDeleted = company.IsDeleted,
                    CountEmployees = company.Employees.Count(),
                    CountOffices = company.Offices.Count()
                }).FirstAsync();

        }

        public async Task EditAsync(CompanyDto dto)
        {
            ValidatorCompany.ValidateCompanyNameIfIsNull(dto.Name);

            var company = await this.context.Companies.FindAsync(dto.Id);
            company.Name = dto.Name;
            company.CreationDate = dto.CreationDate;

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyDto dto)
        {
            var company = await this.context.Companies
                .FindAsync(dto.Id);
            company.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<StringBuilder> ExportCompany()
        {
            var company = await this.GetAllAsync();

            List<CompanyDto> list = company.ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append("Company Name");
            sb.Append("Creation Date");
            sb.Append("Count Employees");
            sb.Append("Count offices");
            sb.Append("\r\n");

            for (int i = 0; i < list.Count(); i++)
            {
                var name = list[i].Name;
                var creationDate = list[i].CreationDate.ToShortDateString();
                var employees = list[i].CountEmployees.ToString();
                var offices = list[i].CountOffices.ToString();

                sb.Append(name + ',');
                sb.Append(creationDate + ',');
                sb.Append(employees + ',');
                sb.Append(offices + ',');

                sb.Append("\r\n");

            }

            return sb;
        }
    }
}
