using System.Collections.Generic;
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
    public class CompanyController : Controller
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [Authorize]
        public async Task<FileResult> Export()
        {
            var company = await this.service.GetAllAsync();

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

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
    }
}