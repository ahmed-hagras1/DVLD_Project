using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class ApplicationTypes
    {
        private static string connectionString = DataAccessSettings.connectionString;

        public static DataTable GetAllApplicationTypes()
        {
            DataTable applicationTypesTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ApplicationTypes;";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        applicationTypesTable.Load(reader);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return applicationTypesTable;
        }

        public static bool UpdateApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE ApplicationTypes
                             SET ApplicationTypeTitle = @applicationTypeTitle,
                                 ApplicationFees = @applicationFees
                             WHERE ApplicationTypeID = @applicationTypeID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationTypeTitle", applicationTypeTitle);
                command.Parameters.AddWithValue("@applicationFees", applicationFees);
                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static int AddNewApplicationType(string applicationTypeTitle, float applicationFees)
        {
            int applicationTypeID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ApplicationTypes
                             (ApplicationTypeTitle, ApplicationFees)
                             VALUES
                             (@applicationTypeTitle, @applicationFees);
                             SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationTypeTitle", applicationTypeTitle);
                command.Parameters.AddWithValue("@applicationFees", applicationFees);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        applicationTypeID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return applicationTypeID;
        }

        public static bool FindApplicationTypeByID(int applicationTypeID, ref string applicationTypeTitle, ref float applicationTypeFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM ApplicationTypes
                             WHERE ApplicationTypeID = @applicationTypeID;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                        applicationTypeFees = Convert.ToSingle(reader["ApplicationFees"]);
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isFound;
        }

        public static bool IsApplicationTypeExist(int applicationTypeID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT 1 FROM ApplicationTypes
                             WHERE ApplicationTypeID = @applicationTypeID;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        isFound = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isFound;
        }

        public static bool IsApplicationTypeExist(string applicationTypeTitle)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT 1 FROM ApplicationTypes
                             WHERE ApplicationTypeTitle = @applicationTypeTitle;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationTypeTitle", applicationTypeTitle);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        isFound = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return isFound;
        }
    }
}

