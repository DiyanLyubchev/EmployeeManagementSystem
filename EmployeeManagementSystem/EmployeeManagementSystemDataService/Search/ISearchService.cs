using EmployeeManagementSystemDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemDataService.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<CompanyDto>> SearchAsync(SearchDto dto);
    }
}