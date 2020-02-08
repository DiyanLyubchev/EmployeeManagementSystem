using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemDataService.Companies;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IOfficeService service;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;

        public OfficeController(IOfficeService service,
            ICompanyService companyService,
            ICountryService countryService,
            ICityService cityService)
        {
            this.service = service;
            this.countryService = countryService;
            this.cityService = cityService;
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listOffices = await this.service.GetAllAsync();

            return View(listOffices);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var office = await GetOfficeViewModelAsync(new OfficeDto());

            return View(office);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OfficeViewModel vm)
        {
            var dto = new OfficeDto
            {
                Id = vm.Id,
                Street = vm.Street,
                StreetNumber = vm.StreetNumber,
                CompanyId = vm.CompanyId,
                CityId = vm.CityId
            };

            await this.service.AddAsync(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var office = await this.service.GetAsync(id);
            var officeVm = await GetOfficeViewModelAsync(office);

            return View("Add", officeVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OfficeViewModel vm)
        {
            var dto = new OfficeDto
            {
                Id = vm.Id,
                Street = vm.Street,
                StreetNumber = vm.StreetNumber,
                CompanyId = vm.CompanyId,
                CityId = vm.CityId
            };

            await this.service.EditAsync(dto);

            return RedirectToAction("Index");
        }

        private async Task<OfficeViewModel> GetOfficeViewModelAsync(OfficeDto office)
        {
            var officeViewModel = new OfficeViewModel
            {
                Id = office.Id,
                Street = office.Street,
                StreetNumber = office.StreetNumber,
                CompanyId = office.CompanyId,
                CountryId = office.CountryId,
                CityId = office.CityId,
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
                CitiesByCountry = office.CountryId == 0 ?
                    Enumerable.Empty<CityViewModel>() :
                    (await this.cityService.GetAllByCountryIdAsync(office.CountryId))
                        .Select(country => new CityViewModel
                        {
                            Id = country.Id,
                            Name = country.Name,
                        }),
            };

            return officeViewModel;
        }
    }
}