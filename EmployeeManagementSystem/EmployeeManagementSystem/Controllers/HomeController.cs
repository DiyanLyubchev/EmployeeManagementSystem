using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystemDataService.Contracts;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICityService cityService;
        private readonly IOfficeService officeService;
       

        public HomeController(ILogger<HomeController> logger, ICityService cityService, IOfficeService officeService)
        {
            _logger = logger;
            this.cityService = cityService;
            this.officeService = officeService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCities(int countryId)
        {
            var city = await this.cityService.GetByCountryAsync(countryId);

            return new JsonResult(city);
        }

        [HttpGet]
        public async Task<IActionResult> GetOffices(int companyId)
        {
            var office = await this.officeService.GetByCompanyAsync(companyId);

            return new JsonResult(office);
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
