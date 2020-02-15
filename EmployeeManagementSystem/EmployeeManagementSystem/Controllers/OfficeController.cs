using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.CustomException;
using EmployeeManagementSystemDataService.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                var listOffices = await this.service.GetAllAsync();

                return View(listOffices);
            }
            catch (OfficeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            try
            {
                var office = await GetOfficeViewModelAsync(new OfficeDto());

                return View(office);
            }
            catch (OfficeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(OfficeViewModel vm)
        {
            try
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
            catch (OfficeException ex)
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
                var office = await this.service.GetAsync(id);
                var officeVm = await GetOfficeViewModelAsync(office);

                return View("Add", officeVm);
            }
            catch (OfficeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
          
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(OfficeViewModel vm)
        {
            try
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
            catch (OfficeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [Authorize]
        public async Task<FileResult> Export()
        {
            var sb = await this.service.ExportOffices();

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Offices.csv");
        }


        [Authorize]
        public async Task<IActionResult> Delete(OfficeViewModel vm)
        {
            try
            {
                var dto = new OfficeDto
                {
                    Id = vm.Id,
                    Street = vm.Street,
                    StreetNumber = vm.StreetNumber,
                    CompanyId = vm.CompanyId,
                    CityId = vm.CityId
                };

                await this.service.DeleteAsync(dto);

                return RedirectToAction("Index");
            }
            catch (OfficeException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
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