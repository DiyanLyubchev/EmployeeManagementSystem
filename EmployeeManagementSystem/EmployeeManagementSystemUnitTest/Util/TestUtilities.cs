using EmployeeManagementSystemData.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemUnitTest.Util
{
    public static class TestUtilities
    {
        public static DbContextOptions<EmployeeManagementSystemContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<EmployeeManagementSystemContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
