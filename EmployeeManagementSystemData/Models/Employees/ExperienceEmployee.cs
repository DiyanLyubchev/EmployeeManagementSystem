using EmployeeManagementSystemData.Models.BaseEntities;
using System.Collections.Generic;

namespace EmployeeManagementSystemData.Models.Employees
{
    public class ExperienceEmployee : BaseEntity
    {
        public string ExperienceLevel { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

