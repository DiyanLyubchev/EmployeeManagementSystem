using System;

namespace EmployeeManagementSystemDataService.CustomException
{
    public class CountryException : Exception
    {
        public CountryException(string masege)
         : base(String.Format(masege))
        {
        }
    }
}
