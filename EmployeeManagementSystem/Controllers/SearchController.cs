using System.Threading.Tasks;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemDataService.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }


        public async Task<IActionResult> SearchCompany([FromQuery]string searchData)
        {
            var dto = new SearchDto { Data = searchData };

            var result = await this.searchService.SearchCompanyAsync(dto);

            return Json(result);
        }


        public async Task<IActionResult> SearchOffice([FromQuery]string searchData)
        {
            var dto = new SearchDto { Data = searchData };

            var result = await this.searchService.SearchOfficeAsync(dto);

            return Json(result);
        }


        public async Task<IActionResult> SearchEmployee([FromQuery]string searchData)
        {
            var dto = new SearchDto { Data = searchData };

            var result = await this.searchService.SearchEmployeeAsync(dto);

            return Json(result);
        }


    }
}
