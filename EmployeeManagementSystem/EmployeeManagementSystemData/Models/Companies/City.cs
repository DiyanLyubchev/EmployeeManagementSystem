using EmployeeManagementSystemData.Models.BaseEntities;
using System.Collections.Generic;

namespace EmployeeManagementSystemData.Models.Companies
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Office> Offices { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
