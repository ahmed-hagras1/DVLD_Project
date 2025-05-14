using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class DetainedLicenses
    {

        public static bool FindDetainedLicenseInfoByID(int detainedID, ref int licenseID ,ref DateTime detainDate,ref float fineFees, ref int createdByUserID,
            ref bool isReleased, ref DateTime releaseDate, ref int releasedByUserID , ref int releasedApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @detainedID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@detainedID", detainedID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    licenseID = (int)reader["LicenseID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    fineFees = Convert.ToSingle(reader["FineFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];

                    releaseDate = (reader["ReleaseDate"] != DBNull.Value) ? (DateTime)reader["ReleaseDate"] : DateTime.MaxValue;
                    releasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? (int)reader["ReleasedByUserID"] : -1;
                    releasedApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? (int)reader["ReleaseApplicationID"] : -1;

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

        public static bool FindDetainedLicenseInfoByLicenseID(int licenseID, ref int detainedID, ref DateTime detainDate, ref float fineFees, ref int createdByUserID,
           ref bool isReleased, ref DateTime releaseDate, ref int releasedByUserID, ref int releasedApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select top 1 * from DetainedLicenses Where LicenseID = @licenseID order by DetainID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseID", licenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    detainedID = (int)reader["DetainID"];
                    detainDate = (DateTime)reader["DetainDate"];
                    fineFees = Convert.ToSingle(reader["FineFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isReleased = (bool)reader["IsReleased"];

                    releaseDate = (reader["ReleaseDate"] != DBNull.Value) ? (DateTime)reader["ReleaseDate"] : DateTime.MaxValue;
                    releasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? (int)reader["ReleasedByUserID"] : -1;
                    releasedApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? (int)reader["ReleaseApplicationID"] : -1;

                    isFound = true;
                }

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
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable detainedLicensesList = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select * from detainedLicenses_View order by IsReleased;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    detainedLicensesList.Load(reader);
                }
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return detainedLicensesList;
        }
        public static int AddNewDetainedLicense( int licenseID,  DateTime detainDate,  float fineFees,  int createdByUserID)
        {
            int detainedID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO DetainedLicenses
                                   (LicenseID
                                   ,DetainDate
                                   ,FineFees
                                   ,CreatedByUserID
                                   ,IsReleased)
                             VALUES
                                   (@licenseID , @detainDate,@fineFees,@createdByUserID, 0);
                        SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@licenseID", licenseID);
            command.Parameters.AddWithValue("@detainDate", detainDate);
            command.Parameters.AddWithValue("@fineFees", fineFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                    detainedID = ID;
            }
            catch (Exception ex ) 
            {

            }
            finally
            {
                connection.Close();
            }

            return detainedID;
        }
        public static bool UpdateDetainedLicense (int detainID ,int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE DetainedLicenses
                              SET LicenseID = @licenseID
                                 ,DetainDate = @detainDate
                                 ,FineFees = @fineFees
                                 ,CreatedByUserID =   @createdByUserID
                            WHERE DetainID = @detainID ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@detainID", detainID);
            command.Parameters.AddWithValue("@licenseID", licenseID);
            command.Parameters.AddWithValue("@detainDate", detainDate);
            command.Parameters.AddWithValue("@fineFees", fineFees);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);


            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool ReleaseDetainedLicense(int detainID, int releasedByUserID, int releaseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE DetainedLicenses
                              SET IsReleased = 1
                                 ,ReleaseDate = @releaseDate
                                 ,ReleasedByUserID = @releasedByUserID
                                 ,ReleaseApplicationID = @releaseApplicationID
                            WHERE DetainID = @detainID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@releaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@releasedByUserID", releasedByUserID);
            command.Parameters.AddWithValue("@releaseApplicationID", releaseApplicationID);
            command.Parameters.AddWithValue("@detainID", detainID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool IsLicenseDetained (int licenseID)
        {
            bool isDetained = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            String query = @"SELECT Found = 1 FROM DetainedLicenses
                              WHERE LicenseID = @licenseID and IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseID", licenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    isDetained = Convert.ToBoolean(result);
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return isDetained;
        }
    }
}
