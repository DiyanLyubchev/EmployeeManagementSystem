using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemData.Models.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
