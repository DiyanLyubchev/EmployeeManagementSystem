using System;

namespace EmployeeManagementSystemDataService.CustomException
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string masege)
          : base(String.Format(masege))
        {
        }
    }
}
