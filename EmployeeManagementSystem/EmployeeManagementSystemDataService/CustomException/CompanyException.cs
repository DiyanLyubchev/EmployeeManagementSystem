using System;
using System.Collections.Generic;
using System.Text;

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
