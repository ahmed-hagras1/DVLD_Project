using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class CountriesDataAccess
    {
        public static bool FindCountry(int countryID , ref string countryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * From Countries Where CountryID = @countryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryID", countryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    countryName = (string)reader["CountryName"];
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool FindCountry(string countryName , ref int countryID )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * From Countries Where CountryName = @countryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    countryID = (int)reader["CountryID"];
                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable(); 
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * From Countries";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows )
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

    }
}
