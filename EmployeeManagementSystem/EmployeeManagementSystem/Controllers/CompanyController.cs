using System.Threading.Tasks;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemDataService.Contracts;
using EmployeeManagementSystemDataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listCompanies = await this.service.GetAllAsync();

            return View(listCompanies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel vm)
        {
            var dto = new CompanyDto
            {
                Name = vm.Name,
                CreationDate = vm.CreationDate
            };

            await this.service.AddAsync(dto);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await this.service.GetAsync(id);
            var companyVm = new CompanyViewModel
            {
                Id = company.Id,
                Name = company.Name,
                CreationDate = company.CreationDate
            };

            return View("Add", companyVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel vm)
        {
            var dto = new CompanyDto
            {
                Id = vm.Id,
                Name = vm.Name,
                CreationDate = vm.CreationDate
            };

            await this.service.EditAsync(dto);

            return RedirectToAction("Index");
        }
    }
}