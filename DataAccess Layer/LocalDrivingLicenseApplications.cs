using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataAccess_Layer
{
    public static class LocalDrivingLicenseApplications
    {

        // Find Local Driving License Application
        static public bool FindLocalDrivingLicenseApplicationByID(int localDrivingLicenseApplicationID, ref int applicationID, ref int licenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationID = (int)reader["ApplicationID"];
                        licenseClassID = (int)reader["LicenseClassID"];
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return isFound;
        }
        static public bool FindLocalDrivingLicenseApplicationByApplicationID(int applicationID, ref int localDrivingLicenseApplicationID, ref int licenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @applicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@applicationID", applicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                        licenseClassID = (int)reader["LicenseClassID"];
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return isFound;
        }

        // Add New Local Driving License Application
        static public int AddNewLocalDrivingLicenseApplication(int applicationID, int licenseClassID)
        {
            int localDrivingLicenseApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications 
                             (ApplicationID, LicenseClassID)
                             VALUES 
                             (@applicationID, @licenseClassID);
                             SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        localDrivingLicenseApplicationID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return localDrivingLicenseApplicationID;
        }

        // Update Local Driving License Application
        static public bool UpdateLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"UPDATE LocalDrivingLicenseApplications 
                             SET ApplicationID = @applicationID, 
                                 LicenseClassID = @licenseClassID
                             WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@licenseClassID", licenseClassID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return (rowsAffected > 0);
        }

        // Delete Local Driving License Application
        static public bool DeleteLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return (rowsAffected > 0);
        }

        // Get All Local Driving License Applications
        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications_View 
                                   ORDER BY ApplicationDate DESC;";
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
                }
            }

            return dataTable;
        }

        // Check if Local Driving License Application Exists
        static public bool IsLocalDrivingLicenseApplicationExist(int localDrivingLicenseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

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
                }
            }

            return isFound;
        }
        public static bool DoesPassTestType(int localDrivingLicenseApplicationID , int testTypeID)
        {
            bool passedStatus = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"select top 1 Tests.TestResult
                              from LocalDrivingLicenseApplications 
                              inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                              inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                              where TestAppointments.TestTypeID = @testTypeID  and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                              ORDER BY Tests.TestResult DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool isPass))
                    passedStatus = isPass;
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return passedStatus;
        }
        public static bool DoesAttendTestType(int localDrivingLicenseApplicationID , int testTypeID )
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select top 1  Found = 1 
                                From LocalDrivingLicenseApplications 
                                inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID and TestAppointments.TestTypeID = @testTypeID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    isFound = true;

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
        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            byte totalTrials = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Count(TestID) as TotalTrialsPerTest
                              from LocalDrivingLicenseApplications
                              inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                              inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                              where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID and TestAppointments.TestTypeID = @testTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();
                
                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte trials))
                    totalTrials = trials;

            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return totalTrials;
        }
        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select top 1 Found = 1 
                              From LocalDrivingLicenseApplications
                              inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                              where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                              and TestAppointments.TestTypeID = @testTypeID
                              and TestAppointments.IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    isFound = true;
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
    }

}
