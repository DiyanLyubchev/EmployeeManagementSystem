using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
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
        public async Task<IActionResult> Index()
        {
            return View(await this.service.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var employee = await GetEmployeeViewModelAsync(new EmployeeDto());

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeViewModel vm)
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await this.service.GetUserAsync(id);
            var officeVm = await GetEmployeeViewModelAsync(employee);

            return View("Add", officeVm);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(OfficeViewModel vm)
        //{
        //    var dto = new OfficeDto
        //    {
        //        Id = vm.Id,
        //        Street = vm.Street,
        //        StreetNumber = vm.StreetNumber,
        //        CompanyId = vm.CompanyId,
        //        CityId = vm.CityId
        //    };

        //    await this.service.EditAsync(dto);

        //    return RedirectToAction("Index");
        //}


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