using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class Applications
    {
        private static string connectionString = DataAccessSettings.connectionString;

        public static bool FindApplication(int applicationID, ref int applicantPersonID, ref DateTime applicationDate,
            ref int applicationTypeID, ref byte applicationStatus, ref DateTime lastStatusDate,
            ref float paidFees, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Applications WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@applicationID", applicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        applicantPersonID = (int)reader["ApplicantPersonID"];
                        applicationDate = (DateTime)reader["ApplicationDate"];
                        applicationTypeID = (int)reader["ApplicationTypeID"];
                        applicationStatus = (byte)reader["ApplicationStatus"];
                        lastStatusDate = (DateTime)reader["LastStatusDate"];
                        paidFees = Convert.ToSingle(reader["PaidFees"]);
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

        public static DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
                            ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID 
                            FROM Applications";
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

        public static int AddNewApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int applicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = @"INSERT INTO Applications 
                            (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, 
                             LastStatusDate, PaidFees, CreatedByUserID)
                            VALUES 
                            (@applicantPersonID, @applicationDate, @applicationTypeID, @applicationStatus, 
                             @lastStatusDate, @paidFees, @createdByUserID);
                            SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
                command.Parameters.AddWithValue("@applicationDate", applicationDate);
                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
                command.Parameters.AddWithValue("@applicationStatus", applicationStatus);
                command.Parameters.AddWithValue("@lastStatusDate", lastStatusDate);
                command.Parameters.AddWithValue("@paidFees", paidFees);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                try
                {
                connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        applicationID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return applicationID;
        }

        public static bool UpdateApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
            int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Applications 
                            SET ApplicantPersonID = @applicantPersonID, 
                                ApplicationDate = @applicationDate, 
                                ApplicationTypeID = @applicationTypeID, 
                                ApplicationStatus = @applicationStatus, 
                                LastStatusDate = @lastStatusDate, 
                                PaidFees = @paidFees, 
                                CreatedByUserID = @createdByUserID
                            WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
                command.Parameters.AddWithValue("@applicationDate", applicationDate);
                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
                command.Parameters.AddWithValue("@applicationStatus", applicationStatus);
                command.Parameters.AddWithValue("@lastStatusDate", lastStatusDate);
                command.Parameters.AddWithValue("@paidFees", paidFees);
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

        public static bool DeleteApplication(int applicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Applications WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@applicationID", applicationID);

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

        public static bool IsApplicationExist(int applicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT 1 FROM Applications WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@applicationID", applicationID);

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
        public static int GetActiveApplicationForLicenseClass(int applicationPersonID, int applicationTypeID, int licenseClassID)
        {
            int activeApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT ActiveApplication = Applications.ApplicationID  
                            FROM Applications
                            INNER JOIN LocalDrivingLicenseApplications 
                            ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            WHERE ApplicantPersonID = @applicationPersonID 
                            AND ApplicationTypeID = @applicationTypeID 
                            AND LocalDrivingLicenseApplications.LicenseClassID = @licenseClassID 
                            AND ApplicationStatus = 1;";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationPersonID", applicationPersonID);
                command.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int appID))
                    {
                        activeApplicationID = appID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return activeApplicationID;
        }

        public static bool UpdateStatus(int applicationID, int newStatus)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Applications
                              SET 
                                  ApplicationStatus = @newStatus,
                                  LastStatusDate = @lastStatusDate
                              WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@newStatus", newStatus);
                command.Parameters.AddWithValue("@lastStatusDate", DateTime.Now);
                command.Parameters.AddWithValue("@applicationID", applicationID);

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
