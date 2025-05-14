using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Country
    {
        public int countryID { get; set; }
        public string countryName { get; set; }

        public Country()
        {
            countryID = default;
            countryName = default;
        }

        private Country(int countryID, string countryName)
        {
            this.countryID = countryID;
            this.countryName = countryName;
        }
        public static Country FindCountry(int countryID)
        {
            string countryName = default;

            if (CountriesDataAccess.FindCountry(countryID, ref countryName))
                return new Country(countryID, countryName);
            else 
                return new Country();
        }

        public static Country FindCountry(string countryName)
        {
            int countryID = default;

            if (CountriesDataAccess.FindCountry(countryName, ref countryID))
                return new Country(countryID, countryName);
            else 
                return new Country();
        }
        public static DataTable GetAllCountries ()
        {
            return CountriesDataAccess.GetAllCountries();
        }

    }
}
