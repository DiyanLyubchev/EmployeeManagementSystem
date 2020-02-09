using EmployeeManagementSystemData.Models.Companies;
using EmployeeManagementSystemDataService.CustomException;
using EmployeeManagementSystemDataService.Models;

namespace EmployeeManagementSystemDataService.Util
{
    public static class ValidatorOffice
    {
        public static void ValidatorAddOfficeIfDtoIsNull(OfficeDto dto)
        {
            if (dto.Street == null || dto.StreetNumber <= 0)
            {
                throw new OfficeException("Incorrect office data!");
            }
        }

        public static void ValidatorAddOfficeIfIdNotExist(int id)
        {
            if (id <= 0)
            {
                throw new OfficeException("Id does not exist !");
            }
        }

        public static bool ValidatorForUpdateOfficeStreet(OfficeDto dto)
        {
            if (dto.Street == null)
            {
                return false;
            }

            return true;
        }

        public static bool ValidatorForUpdateOfficeStreetNumber(OfficeDto dto)
        {
            if (dto.StreetNumber <= 0)
            {
                return false;
            }

            return true;
        }

        public static void ValidatorOffices(Office office)
        {
            if (office == null)
            {
                throw new OfficeException("Office does not exist");
            }
        }
    }  
}

