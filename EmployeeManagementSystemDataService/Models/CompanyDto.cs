using System;

namespace EmployeeManagementSystemDataService.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public int CountEmployees { get; set; }

        public int CountOffices { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
