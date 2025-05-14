using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class TestAppointments
    {

        static public bool FindTestAppointment(int testAppointmentID, ref int testTypeID,
    ref int localDrivingLicenseApplicationID, ref DateTime appointmentDate,
    ref float paidFees, ref int createdByUserID, ref bool isLocked , ref int retakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @testAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    testTypeID = (int)reader["TestTypeID"];
                    localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        retakeTestApplicationID = -1;
                    else
                        retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                        isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool FindLastTestAppointment(int localDrivingLicenseApplicationID, int testTypeID,ref int testAppointmentID,
            ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID,
            ref bool isLocked, ref int retakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string query = @"Select Top 1 * from TestAppointments
                              Where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                              And TestTypeID = @testTypeID
                              order by TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    testAppointmentID = (int)reader["TestAppointmentID"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        retakeTestApplicationID = -1;
                    else
                        retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public int AddNewTestAppointment(int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked , int retakeTestApplicationID)
        {
            int testAppointmentID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO TestAppointments
                    (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, 
                     PaidFees, CreatedByUserID, IsLocked , RetakeTestApplicationID)
                    VALUES
                    (@testTypeID, @localDrivingLicenseApplicationID, @appointmentDate, 
                     @paidFees, @createdByUserID, @isLocked , @retakeTestApplicationID);
                    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);

            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@retakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@retakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    testAppointmentID = insertedID;
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return testAppointmentID;
        }

        static public bool UpdateTestAppointment(int testAppointmentID, int testTypeID,
            int localDrivingLicenseApplicationID, DateTime appointmentDate,
            float paidFees, int createdByUserID, bool isLocked , int retakeTestApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE TestAppointments
                    SET TestTypeID = @testTypeID,
                        LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID,
                        AppointmentDate = @appointmentDate,
                        PaidFees = @paidFees,
                        CreatedByUserID = @createdByUserID,
                        IsLocked = @isLocked,
						RetakeTestApplicationID = @retakeTestApplicationID
                    WHERE TestAppointmentID = @testAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@paidFees", paidFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);

            if (retakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@retakeTestApplicationID", retakeTestApplicationID);
            else
                command.Parameters.AddWithValue("@retakeTestApplicationID", DBNull.Value);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        static public bool DeleteTestAppointment(int testAppointmentID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @testAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }

        static public DataTable GetAllTestAppointments()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select * from TestAppointments_View;";

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
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
        public static DataTable GetAllTestAppointmentsPerTestType(int localDrivingLicenseApplicationID , int testTypeID)
        {
            DataTable listAppointments = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT [TestAppointmentID]
                                ,[AppointmentDate]
                                ,[PaidFees]
                                ,[IsLocked]
                            FROM [dbo].[TestAppointments]
                            Where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                            and TestTypeID = @testTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    listAppointments.Load(reader);
                    
            }
            catch (Exception ex) 
            {

            }
            finally
            {
                connection.Close();
            }

            return listAppointments;
        }

        static public bool IsTestAppointmentExist(int testAppointmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @testAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool IsTestAppointmentExistForApplication(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT 1 FROM TestAppointments 
                    WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                    AND TestTypeID = @testTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                isFound = (result != null);
            }
            catch (Exception ex)
            {
                // Consider logging the exception
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int GetTestID (int testAppointmentID)
        {
            int testID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT Tests.TestID
                            FROM     Tests INNER JOIN
                                              TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE TestAppointments.TestAppointmentID = @testAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result == null || !int.TryParse(result.ToString(), out testID))
                    testID = -1;
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return testID;
        }
    }
}
