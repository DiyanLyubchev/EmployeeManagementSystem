using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystemDataService.CustomException
{
    public class CityException : Exception
    {
        public CityException(string masege)
         : base(String.Format(masege))
        {
        }
    }
}
