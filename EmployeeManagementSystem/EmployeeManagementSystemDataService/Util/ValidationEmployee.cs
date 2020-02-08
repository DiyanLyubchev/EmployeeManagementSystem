using EmployeeManagementSystemDataService.CustomException;

namespace EmployeeManagementSystemDataService.Util
{
    public static class ValidationEmployee
    {
        public static void ValidationEmployeeFirstNameLength(string firstName)
        {
            if (firstName.Length < 3 || firstName.Length > 20)
            {
                throw new EmployeeException("Incorrect length of first name!");
            }
        }

        public static void ValidationEmployeeLastNameLength(string lastName)
        {
            if (lastName.Length < 3 || lastName.Length > 20)
            {
                throw new EmployeeException("Incorrect length of last name!");
            }
        }
        public static void ValidationEmployeeCompanyId(int id)
        {
            if (id == 0)
            {
                throw new EmployeeException("Incorrect company id!");
            }
        }

        public static void ValidationEmployeeOfficeId(int? id)
        {
            if (id.HasValue && id == 0)
            {
                throw new EmployeeException("Incorrect office id!");
            }
        }

        public static void ValidationEmployeeExperienceEmployeeId(int id)
        {
            if (id == 0)
            {
                throw new EmployeeException("Incorrect experience level!");
            }
        }
    }
}


