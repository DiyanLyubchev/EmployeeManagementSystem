﻿using EmployeeManagementSystemData.Models.Context;
using EmployeeManagementSystemDataService.CustomException;
using EmployeeManagementSystemDataService.Employees;
using EmployeeManagementSystemDataService.Models;
using EmployeeManagementSystemUnitTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemUnitTest.Employee_Should
{
    [TestClass]
    public class Employee_Test
    {

        [TestMethod]
        public async Task AddEmployee_Test()
        {
            var employee = EmployeeGeneratorUtil.GenerateEmployee();
            var options = TestUtilities.GetOptions(nameof(AddEmployee_Test));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                await actContext.Employees.AddAsync(employee);

                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new EmployeeManagementSystemContext(options))
            {
                Assert.AreEqual(1, assertContext.Employees.Count());

            }
        }


        [TestMethod]
        [ExpectedException(typeof(EmployeeException))]
        public async Task ThrowException_IfFirstNameLengthIsShort()
        {
            var employee = EmployeeGeneratorUtil.GenerateEmployee();

            var dto = new EmployeeDto
            {
                FirstName = "Ts",
                LastName = employee.LastName,
                CompanyId = employee.CompanyId,
                OfficeId = employee.OfficeId,
                ExperienceEmployeeId = employee.ExperienceEmployeeId
            };

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfFirstNameLengthIsShort));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                var sut = new EmployeeService(actContext);
                var resilt = await sut.AddAsync(dto);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(EmployeeException))]
        public async Task ThrowException_IfFirstNameLengthIsLong()
        {
            var employee = EmployeeGeneratorUtil.GenerateEmployee();
            var firstName = new String('t', 21);

            var dto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = employee.LastName,
                CompanyId = employee.CompanyId,
                OfficeId = employee.OfficeId,
                ExperienceEmployeeId = employee.ExperienceEmployeeId
            };

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfFirstNameLengthIsLong));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                var sut = new EmployeeService(actContext);
                var resilt = await sut.AddAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmployeeException))]
        public async Task ThrowException_IfLastNameLengthIsShort()
        {
            var employee = EmployeeGeneratorUtil.GenerateEmployee();

            var dto = new EmployeeDto
            {
                FirstName = employee.FirstName,
                LastName = "Ts",
                CompanyId = employee.CompanyId,
                OfficeId = employee.OfficeId,
                ExperienceEmployeeId = employee.ExperienceEmployeeId
            };

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfLastNameLengthIsShort));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                var sut = new EmployeeService(actContext);
                var resilt = await sut.AddAsync(dto);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(EmployeeException))]
        public async Task ThrowException_IfLastNameLengthIsLong()
        {
            var employee = EmployeeGeneratorUtil.GenerateEmployee();
            var lastName = new String('t', 21);

            var dto = new EmployeeDto
            {
                FirstName = employee.FirstName,
                LastName = lastName,
                CompanyId = employee.CompanyId,
                OfficeId = employee.OfficeId,
                ExperienceEmployeeId = employee.ExperienceEmployeeId
            };

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfLastNameLengthIsLong));

            using (var actContext = new EmployeeManagementSystemContext(options))
            {
                var sut = new EmployeeService(actContext);
                var resilt = await sut.AddAsync(dto);
            }
        }

    }
}
