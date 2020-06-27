using System;

namespace EmployeeManagementSystemDataService.CustomException
{
    public class CompanyException : Exception
    {
        public CompanyException(string masege)
         : base(String.Format(masege))
        {
        }
    }
}
