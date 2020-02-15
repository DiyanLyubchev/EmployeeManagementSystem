﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemData.Common;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.CustomException;
using EmployeeManagementSystemDataService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;
        private readonly IOfficeService officeService;

        public EmployeeController(IEmployeeService service,
            ICountryService countryService,
            ICityService cityService,
            ICompanyService companyService,
            IOfficeService officeService)
        {
            this.service = service;
            this.countryService = countryService;
            this.cityService = cityService;
            this.companyService = companyService;
            this.officeService = officeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await this.service.GetAllAsync();
                return View(employees);
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }


        }

        [Authorize]
        public async Task<FileResult> Export()
        {
            var employees = await this.service.GetAllAsync();

            List<EmployeeDto> list = employees.ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("First Name");
            sb.Append("Last Name");
            sb.Append("Experience Level");
            sb.Append("Starting Date");
            sb.Append("Vacation Days");
            sb.Append("Salary");
            sb.Append("Company");
            sb.Append("Country");
            sb.Append("City");
            sb.Append("\r\n");

            for (int i = 0; i < list.Count(); i++)
            {
                var firstName = list[i].FirstName;
                var lastName = list[i].LastName;
                var experience = ((ExperienceEmployeeType)list[i].ExperienceEmployeeId).ToString();
                var startingDate = list[i].StartingDate.ToShortDateString().ToString();
                var vacationDays = list[i].VacationDays.ToString();
                var salary = list[i].Salary.ToString();
                var companyNAme = list[i].CompanyName;
                var locationCountry = list[i].CountryName;
                var locationCity = list[i].CityName;

                sb.Append(firstName + ',');
                sb.Append(lastName + ',');
                sb.Append(experience + ',');
                sb.Append(startingDate + ',');
                sb.Append(vacationDays + ',');
                sb.Append(salary + ',');
                sb.Append(companyNAme + ',');
                sb.Append(locationCountry + ',');
                sb.Append( locationCity);

                sb.Append("\r\n");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
        

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            try
            {
                var employee = await GetEmployeeViewModelAsync(new EmployeeDto());
                return View(employee);
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(EmployeViewModel vm)
        {
            try
            {
                var dto = new EmployeeDto
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    VacationDays = vm.VacationDays,
                    ExperienceEmployeeId = vm.ExperienceEmployee,
                    Salary = vm.Salary,
                    CompanyName = vm.CompanyName,
                    CompanyId = vm.CompanyId,
                    OfficeId = vm.OfficeId
                };

                await this.service.AddAsync(dto);

                return RedirectToAction("Index");
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var employee = await this.service.GetEmployeeAsync(id);
                var employeeVm = await GetEmployeeViewModelAsync(employee);

                return View("Add", employeeVm);
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EmployeViewModel vm)
        {
            try
            {
                var dto = new EmployeeDto
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    ExperienceEmployeeId = vm.ExperienceEmployee,
                    VacationDays = vm.VacationDays,
                    Salary = vm.Salary,
                    CompanyName = vm.CompanyName,
                    CityName = vm.CityName,
                    CountryName = vm.CountryName,
                    OfficeId = vm.OfficeId,

                };

                await this.service.EditAsync(dto);

                return RedirectToAction("Index");
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(EmployeViewModel vm)
        {
            try
            {
                var dto = new EmployeeDto
                {
                    Id = vm.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    ExperienceEmployeeId = vm.ExperienceEmployee,
                    VacationDays = vm.VacationDays,
                    Salary = vm.Salary,
                    CompanyName = vm.CompanyName,
                    CityName = vm.CityName,
                    CountryName = vm.CountryName,
                    OfficeId = vm.OfficeId,

                };

                await this.service.DeleteEmployeeAsync(dto);

                return RedirectToAction("Index");
            }
            catch (EmployeeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        private async Task<EmployeViewModel> GetEmployeeViewModelAsync(EmployeeDto employee)
        {
            var employeeViewModel = new EmployeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ExperienceEmployee = employee.ExperienceEmployeeId,
                VacationDays = employee.VacationDays,
                Salary = employee.Salary,
                CompanyName = employee.CompanyName,
                OfficeId = employee.OfficeId,
                CompanyId = employee.CompanyId,
                CountryId = employee.CompanyId,
                CityId = employee.CompanyId,
                AllCompanies = (await this.companyService.GetAllAsync()).Select(company => new CompanyViewModel
                {
                    Id = company.Id,
                    Name = company.Name,
                    CreationDate = company.CreationDate
                }),
                AllCountries = (await this.countryService.GetAllAsync()).Select(country => new CountryViewModel
                {
                    Id = country.Id,
                    Name = country.Name,
                }),
                CitiesByCountry = employee.CountryId == 0 ?
                    Enumerable.Empty<CityViewModel>() :
                    (await this.cityService.GetAllByCountryIdAsync(employee.CountryId))
                        .Select(country => new CityViewModel
                        {
                            Id = country.Id,
                            Name = country.Name,
                        }),
                AllOfficies = (await this.officeService.GetAllAsync()).Select(office => new OfficeViewModel
                {
                    Id = office.Id,
                    Street = office.Street,
                    StreetNumber = office.StreetNumber
                }),
            };

            return employeeViewModel;
        }
    }
}