using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.Companies;
using EmployeeManagementSystemDataService.CustomException;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemUnitTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemUnitTest.Company_Should
{
    [TestClass]
    public class Company_Test
    {
        [TestMethod]
        [ExpectedException(typeof(CompanyException))]
        public async Task ThrowException_IfCompanyNameIsNull_Test()
        {
            var company = CompanyGeneratorUtil.GenerateCompany();

            var dto = new CompanyDto
            {
                CreationDate = company.CreationDate,
                Name = null
            };

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfCompanyNameIsNull_Test));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                var sut = new CompanyService(actContext);
                await sut.AddAsync(dto);
            }
        }
    }
}
