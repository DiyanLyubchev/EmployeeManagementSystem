using EmployeeManagementSystemData.Models.BaseEntities;
using System.Collections.Generic;

namespace EmployeeManagementSystemData.Models.Companies
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
