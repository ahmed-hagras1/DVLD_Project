using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class LicenseClasses
    {
        private static string connectionString = DataAccessSettings.connectionString;

        // Find a LicenseClass by LicenseClassID
        public static bool FindLicenseClass(int licenseClassID, ref string className, ref string classDescription,
                                            ref byte minimumAllowedAge, ref byte defaultValidityLength, ref float classFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @licenseClassID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        className = reader["ClassName"].ToString();
                        classDescription = reader["ClassDescription"].ToString();
                        minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                        defaultValidityLength = (byte)reader["DefaultValidityLength"];
                        classFees = Convert.ToSingle(reader["ClassFees"]);

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

        // Find a LicenseClass by ClassName
        public static bool FindLicenseClass(string className, ref int licenseClassID, ref string classDescription,
                                            ref byte minimumAllowedAge, ref byte defaultValidityLength, ref float classFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE ClassName = @className";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@className", className);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        licenseClassID = (int)reader["LicenseClassID"];
                        classDescription = reader["ClassDescription"].ToString();
                        minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                        defaultValidityLength = (byte)reader["DefaultValidityLength"];
                        classFees = Convert.ToSingle(reader["ClassFees"]);

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

        // Add a new LicenseClass
        public static int AddNewLicenseClass(string className, string classDescription, byte minimumAllowedAge,
                                             byte defaultValidityLength, float classFees)
        {
            int licenseClassID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO LicenseClasses 
                             (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                             VALUES 
                             (@className, @classDescription, @minimumAllowedAge, @defaultValidityLength, @classFees);
                             SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@className", className);
                command.Parameters.AddWithValue("@classDescription", classDescription);
                command.Parameters.AddWithValue("@minimumAllowedAge", minimumAllowedAge);
                command.Parameters.AddWithValue("@defaultValidityLength", defaultValidityLength);
                command.Parameters.AddWithValue("@classFees", classFees);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        licenseClassID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return licenseClassID;
        }

        // Update an existing LicenseClass
        public static bool UpdateLicenseClass(int licenseClassID, string className, string classDescription,
                                              byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE LicenseClasses 
                             SET ClassName = @className, 
                                 ClassDescription = @classDescription, 
                                 MinimumAllowedAge = @minimumAllowedAge, 
                                 DefaultValidityLength = @defaultValidityLength, 
                                 ClassFees = @classFees
                             WHERE LicenseClassID = @licenseClassID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
                command.Parameters.AddWithValue("@className", className);
                command.Parameters.AddWithValue("@classDescription", classDescription);
                command.Parameters.AddWithValue("@minimumAllowedAge", minimumAllowedAge);
                command.Parameters.AddWithValue("@defaultValidityLength", defaultValidityLength);
                command.Parameters.AddWithValue("@classFees", classFees);

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

        // Delete a LicenseClass by LicenseClassID
        public static bool DeleteLicenseClass(int licenseClassID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @licenseClassID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

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

        // Get all LicenseClasses
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM LicenseClasses";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dataTable;
        }

        // Check if a LicenseClass exists by LicenseClassID
        public static bool IsLicenseClassExist(int licenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT 1 FROM LicenseClasses WHERE LicenseClassID = @licenseClassID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

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
