using EmployeeManagementSystemData.Models.Companies;
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

        public static bool ValidateCompanyIfExist(Company company)
        {
            if (company != null)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateCompanyIfNotExistExist(Company company)
        {
            if (company.Name == null)
            {
                return true;
            }

            return false;
        }

        public static bool ValidateIfCompanyIsNull(Company company)
        {
            if (company == null)
            {
                return false;
            }

            return true;
        }
    }
}
