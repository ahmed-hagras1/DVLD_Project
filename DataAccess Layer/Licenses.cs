using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class Licenses
    {
        private static string connectionString = DataAccessSettings.connectionString;

        // Find a License by LicenseID
        public static bool FindLicense(int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
                                       ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
                                       ref float paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Licenses WHERE LicenseID = @licenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationID = (int)reader["ApplicationID"];
                        driverID = (int)reader["DriverID"];
                        licenseClass = (int)reader["LicenseClass"];
                        issueDate = (DateTime)reader["IssueDate"];
                        expirationDate = (DateTime)reader["ExpirationDate"];
                        notes = reader["Notes"].ToString();
                        paidFees =Convert.ToSingle(reader["PaidFees"]);
                        isActive = (bool)reader["IsActive"];
                        issueReason = (byte)reader["IssueReason"];
                        createdByUserID = (int)reader["CreatedByUserID"];

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

        // Get all Licenses
        public static DataTable GetAllLicenses()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, 
                             ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID 
                             FROM Licenses";
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
        public static DataTable GetAllLicensesOwnedByDriver(int driverID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Select Licenses.LicenseID , ApplicationID , LicenseClasses.ClassName , IssueDate, ExpirationDate, IsActive
                                 From Licenses
                                 inner join LicenseClasses on Licenses.LicenseClass = LicenseClasses.LicenseClassID
                                 Where Licenses.DriverID = @driverID;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@driverID", driverID);

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

        // Add a new License
        public static int AddNewLicense(int applicationID, int driverID, int licenseClass, DateTime issueDate,
                                        DateTime expirationDate, string notes, float paidFees, bool isActive,
                                        byte issueReason, int createdByUserID)
        {
            int licenseID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Licenses 
                            (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, 
                             PaidFees, IsActive, IssueReason, CreatedByUserID)
                            VALUES 
                            (@applicationID, @driverID, @licenseClass, @issueDate, @expirationDate, @notes, 
                             @paidFees, @isActive, @issueReason, @createdByUserID);
                            SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@driverID", driverID);
                command.Parameters.AddWithValue("@licenseClass", licenseClass);
                command.Parameters.AddWithValue("@issueDate", issueDate);
                command.Parameters.AddWithValue("@expirationDate", expirationDate);

                if(notes == string.Empty)
                    command.Parameters.AddWithValue("@notes", System.DBNull.Value);
                else
                    command.Parameters.AddWithValue("@notes", notes);


                command.Parameters.AddWithValue("@paidFees", paidFees);
                command.Parameters.AddWithValue("@isActive", isActive);
                command.Parameters.AddWithValue("@issueReason", issueReason);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        licenseID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return licenseID;
        }

        // Update an existing License
        public static bool UpdateLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                                         DateTime issueDate, DateTime expirationDate, string notes,
                                         float paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Licenses 
                            SET ApplicationID = @applicationID, 
                                DriverID = @driverID, 
                                LicenseClass = @licenseClass, 
                                IssueDate = @issueDate, 
                                ExpirationDate = @expirationDate, 
                                Notes = @notes, 
                                PaidFees = @paidFees, 
                                IsActive = @isActive, 
                                IssueReason = @issueReason, 
                                CreatedByUserID = @createdByUserID
                            WHERE LicenseID = @licenseID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@licenseID", licenseID);
                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@driverID", driverID);
                command.Parameters.AddWithValue("@licenseClass", licenseClass);
                command.Parameters.AddWithValue("@issueDate", issueDate);
                command.Parameters.AddWithValue("@expirationDate", expirationDate);

                if (notes == string.Empty)
                    command.Parameters.AddWithValue("@notes", System.DBNull.Value);
                else
                    command.Parameters.AddWithValue("@notes", notes);

                command.Parameters.AddWithValue("@paidFees", paidFees);
                command.Parameters.AddWithValue("@isActive", isActive);
                command.Parameters.AddWithValue("@issueReason", issueReason);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

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

        // Delete a License by LicenseID
        public static bool DeleteLicense(int licenseID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Licenses WHERE LicenseID = @licenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

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

        // Check if a License exists by LicenseID
        public static bool IsLicenseExist(int licenseID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT 1 FROM Licenses WHERE LicenseID = @licenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@licenseID", licenseID);

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

        // Get Active LicenseID by Person and LicenseClass
        public static int GetActiveLicenseIDByPerson(int personID, int licenseClassID)
        {
            int licenseID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT Licenses.LicenseID 
                             FROM Licenses
                             INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
                             WHERE Drivers.PersonID = @personID 
                             AND Licenses.LicenseClass = @licenseClassID 
                             AND Licenses.IsActive = 1";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@personID", personID);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        licenseID = ID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return licenseID;
        }
        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            int licenseID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Select licenseID from Licenses where ApplicationID = @applicationID;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationID", applicationID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ID))
                    {
                        licenseID = ID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return licenseID;
        }
        // Deactivate a License
        public static bool DeactivateLicense(int licenseID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Licenses 
                            SET IsActive = 0 
                            WHERE LicenseID = @licenseID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@licenseID", licenseID);

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
       
    }
}