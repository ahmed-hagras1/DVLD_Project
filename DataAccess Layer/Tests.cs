using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class Tests
    {
        static public bool FindTest(int testID, ref int testAppointmentID, ref bool testResult, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM Tests WHERE TestID = @testID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@testID", testID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        testAppointmentID = (int)reader["TestAppointmentID"];
                        testResult = (bool)reader["TestResult"];
                        notes = reader["Notes"].ToString();
                        createdByUserID = (int)reader["CreatedByUserID"];

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
        public static bool FindLastTestByPersonAndTestTypeAndLicenseClass(int personID , int testTypeID , int licenseClassId ,
            ref int testID, ref int testAppointmentID, ref bool testResult, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT top 1 Tests.*, Applications.ApplicantPersonID
                             FROM     LocalDrivingLicenseApplications INNER JOIN
                                               TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                               Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID INNER JOIN
                                               Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             WHERE Applications.ApplicantPersonID = @personID
                             and TestAppointments.TestTypeID = @testTypeID
                             and LocalDrivingLicenseApplications.LicenseClassID = @licenseClassId
                             Order by Tests.TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@licenseClassId", licenseClassId);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    testID = (int)reader["TestID"];
                    testAppointmentID = (int)reader["TestAppointmentID"];
                    testResult = (bool)reader["TestResult"];
                    notes = reader["Notes"].ToString();
                    createdByUserID = (int)reader["CreatedByUserID"];

                    isFound = true;
                }

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
        static public DataTable GetAllTests()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"SELECT * FROM Tests";
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

        static public int AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int testID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                // insert new test and locked this test appointment.
                string query = @"INSERT INTO Tests 
                            (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES 
                            (@testAppointmentID, @testResult, @notes, @createdByUserID);

                              UPDATE [dbo].[TestAppointments]
                                 SET 
                                    IsLocked = 1
                               WHERE TestAppointmentID = @testAppointmentID
                            SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
                command.Parameters.AddWithValue("@testResult", testResult);

                if(notes.Trim() == "")
                    command.Parameters.AddWithValue("@notes", System.DBNull.Value);
                else
                    command.Parameters.AddWithValue("@notes", notes);

                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        testID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (log or rethrow)
                }
            }

            return testID;
        }

        static public bool UpdateTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"UPDATE Tests 
                            SET TestAppointmentID = @testAppointmentID, 
                                TestResult = @testResult, 
                                Notes = @notes, 
                                CreatedByUserID = @createdByUserID
                            WHERE TestID = @testID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@testID", testID);
                command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
                command.Parameters.AddWithValue("@testResult", testResult);
                command.Parameters.AddWithValue("@notes", notes);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

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

        static public bool DeleteTest(int testID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "DELETE FROM Tests WHERE TestID = @testID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@testID", testID);

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
        public static byte GetPassedTestCount(int localDrivingLicenseApplicationID)
        {
            byte passedTestCount = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select passedTestCount = COUNT(TestAppointments.TestTypeID)
                              From Tests
                              inner join TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                              Where TestAppointments.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID and Tests.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte count))
                    passedTestCount = count;

            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return passedTestCount;
        }

    }

}
