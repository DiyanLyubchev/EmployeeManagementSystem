using System;

namespace EmployeeManagementSystemDataService.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
