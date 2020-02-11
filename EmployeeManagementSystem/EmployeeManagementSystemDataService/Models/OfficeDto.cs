namespace EmployeeManagementSystemDataService.Models
{
    public class OfficeDto
    {   
        public int Id { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int CompanyId { get; set; }

        public bool IsDeleted { get; set; }

        public bool CompanyIsDeleted { get; set; }

        public string CompanyName { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }
    }
}
