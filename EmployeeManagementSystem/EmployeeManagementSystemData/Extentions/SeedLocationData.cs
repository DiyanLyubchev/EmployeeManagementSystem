using EmployeeManagementSystemData.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeManagementSystemData.Extentions
{
    public static class SeedLocationData
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            string countriesJson = File.ReadAllText(@"App_Data\countries.json");

            var countriesDict = new Dictionary<string, Country>();

            var countriesAnonymous = new[] {
                new { Name = "", Code = "" }
            };

            int countryId = 1;
            foreach (var country in JsonConvert.DeserializeAnonymousType(countriesJson, countriesAnonymous))
            {
                countriesDict.Add(country.Code, new Country { Id = countryId++, Name = country.Name });
            }

            modelBuilder.Entity<Country>().HasData(countriesDict.Values);
        }

        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            string citiesJson = File.ReadAllText(@"App_Data\cities.json");
            string countriesJson = File.ReadAllText(@"App_Data\countries.json");

            var countriesDict = new Dictionary<string, int>();
            var citiesList = new List<City>();

            var countriesAnonymous = new[] {
                new { Name = "", Code = "" }
            };

            int countryId = 1;
            foreach (var country in JsonConvert.DeserializeAnonymousType(countriesJson, countriesAnonymous))
            {
                countriesDict.Add(country.Code, countryId++);
            }

            var citiesAnonymous = new[] {
                new { Name = "", Country = "" }
            };

            int citiesId = 1;
            foreach (var city in JsonConvert.DeserializeAnonymousType(citiesJson, citiesAnonymous))
            {
                if (countriesDict.ContainsKey(city.Country))
                {
                    var cityEntity = new City { Id = citiesId++, Name = city.Name, CountryId = countriesDict[city.Country] };
                    citiesList.Add(cityEntity);
                }
            }

            modelBuilder.Entity<City>().HasData(citiesList.Take(20000));
        }
    }
}
