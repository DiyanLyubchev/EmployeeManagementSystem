using EmployeeManagementSystemDataService.CustomException;
using System;

namespace EmployeeManagementSystemDataService.Util
{
    public static class ValidatorCompany
    {
        public static void ValidateCompanyNameIfIsNull(string name)
        {
            if (name == null)
            {
                throw new CompanyException("Incorrect company name");
            }
        }

        public static void ValidateCompanyCreationDateIfIsNull(DateTime? date)
        {
            if (date == null)
            {
                throw new CompanyException("Incorrect company date");
            }
        }
    }
}
