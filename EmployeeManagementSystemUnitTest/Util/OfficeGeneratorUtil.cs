using EmployeeManagementSystemData.Models.Companies;

namespace EmployeeManagementSystemUnitTest.Util
{
    public static class OfficeGeneratorUtil
    {
        public static Office GenerateOffice()
        {
            var address = "TestName";
            var addressNumber = 12;


            var office = new Office
            {
                Id = 1,
                Street = address,
                StreetNumber = addressNumber,
            };

            return office;
        }
    }
}
