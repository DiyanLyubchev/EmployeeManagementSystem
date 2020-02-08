using System;

namespace EmployeeManagementSystemDataService.CustomException
{
    public class OfficeException : Exception
    {
        public OfficeException(string masege)
        : base(String.Format(masege))
        {
        }
    }
}
