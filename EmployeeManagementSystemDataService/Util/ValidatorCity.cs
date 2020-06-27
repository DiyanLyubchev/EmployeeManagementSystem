using EmployeeManagementSystemDataService.CustomException;

namespace EmployeeManagementSystemDataService.Util
{
    public static class ValidatorCity
    {
        public static void ValidatorAddCountryIfCityNameIsNull(string cityName)
        {
            if (cityName == null)
            {
                throw new CityException("Incorrect data of city");
            }
        }
    }
}
