using EmployeeManagementSystemData.Models.Context;

namespace EmployeeManagementSystemDataService.Search
{
    public class SearchService
    {
        private readonly EmployeeManagementSystemContext context;

        public SearchService(EmployeeManagementSystemContext context)
        {
            this.context = context;
        }

       
    }
}
