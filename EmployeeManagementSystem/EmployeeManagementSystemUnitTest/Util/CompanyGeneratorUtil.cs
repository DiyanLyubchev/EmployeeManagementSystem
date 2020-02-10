using EmployeeManagementSystemData.Models.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystemUnitTest.Util
{
    public static class CompanyGeneratorUtil
    {
        public static Company GenerateCompany()
        {
            var comanyName = "TestName";

            var company = new Company
            {
                Id = 1,
                CreationDate = DateTime.Now,
                Name = comanyName
            };

            return company;
        }
    }
}
