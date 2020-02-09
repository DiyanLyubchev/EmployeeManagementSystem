using EmployeeManagementSystemData.Models.BaseEntities;
using EmployeeManagementSystemData.Models.Companies;
using System;

namespace EmployeeManagementSystemData.Models.Employees
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartingDate { get; set; }

        public decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public int CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Company Company { get; set; }

        public int? OfficeId { get; set; }

        public virtual Office Office { get; set; }

        public int ExperienceEmployeeId { get; set; }

        public virtual ExperienceEmployee Experience { get; set; }
    }
}
