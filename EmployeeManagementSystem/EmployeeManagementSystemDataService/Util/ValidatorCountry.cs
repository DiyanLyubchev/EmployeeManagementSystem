using EmployeeManagementSystemDataService.CustomException;

namespace EmployeeManagementSystemDataService.Util
{
    public static class ValidatorCountry
    {
        public static void ValidatorAddCountryIfCountryNameIsNull(string countryName)
        {
            if (countryName == null)
            {
                throw new CountryException("Incorrect data of country!");
            }
        }
    }
}
