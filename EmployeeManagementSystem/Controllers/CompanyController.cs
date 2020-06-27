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
            try
            {
                var listCompanies = await this.service.GetAllAsync();

                return View(listCompanies);
            }
            catch (CompanyException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel vm)
        {
            try
            {
                var dto = new CompanyDto
                {
                    Name = vm.Name,
                    CreationDate = vm.CreationDate
                };

                await this.service.AddAsync(dto);

                return RedirectToAction("Index");
            }
            catch (CompanyException ex)
            {

                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
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
            catch (CompanyException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel vm)
        {
            try
            {
                var dto = new CompanyDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    CreationDate = vm.CreationDate
                };

                await this.service.EditAsync(dto);

            }
            catch (CompanyException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(CompanyViewModel vm)
        {
            try
            {
                var dto = new CompanyDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    CreationDate = vm.CreationDate
                };

                await this.service.DeleteAsync(dto);

            }
            catch (CompanyException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return RedirectToAction("Index");
        }

     
        public async Task<FileResult> Export()
        {
            var sb = await this.service.ExportCompany();

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Companies.csv");
        }
    }
}