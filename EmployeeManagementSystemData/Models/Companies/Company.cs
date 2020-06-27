using EmployeeManagementSystemData.Models.BaseEntities;
using EmployeeManagementSystemData.Models.Employees;
using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemData.Models.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Office> Offices { get; set; }
    }
}
