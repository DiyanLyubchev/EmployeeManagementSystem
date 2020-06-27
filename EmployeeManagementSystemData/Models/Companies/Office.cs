using EmployeeManagementSystemData.Models.BaseEntities;
using EmployeeManagementSystemData.Models.Employees;
using System.Collections.Generic;

namespace EmployeeManagementSystemData.Models.Companies
{
    public class Office : BaseEntity
    {
        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public int CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Company Company { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
