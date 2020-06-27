using EmployeeManagementSystemData.Models.Employees;

namespace EmployeeManagementSystemUnitTest.Util
{
    public static class EmployeeGeneratorUtil
    {
        public static Employee GenerateEmployee()
        {
            var firstName = "TestUsername";
            var LastName = "TestPassword";
            var experience = 2;
            var companyId = 4;
            var officeID = 2;

            var user = new Employee
            {
                FirstName = firstName,
                LastName = LastName,
                ExperienceEmployeeId = experience,
                CompanyId = companyId,
                OfficeId = officeID
            };

            return user;
        }
    }
}
