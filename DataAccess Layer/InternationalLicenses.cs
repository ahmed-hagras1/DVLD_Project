using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class InternationalLicenses
    {
            static public bool FindInternationalLicense(int internationalLicenseID, ref int applicationID,
                ref int driverID, ref int issuedUsingLocalLicenseID, ref DateTime issueDate,
                ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @internationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        applicationID = (int)reader["ApplicationID"];
                        driverID = (int)reader["DriverID"];
                         issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                        issueDate = (DateTime)reader["IssueDate"];
                        expirationDate = (DateTime)reader["ExpirationDate"];
                        isActive = (bool)reader["IsActive"];
                        createdByUserID = (int)reader["CreatedByUserID"];

                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

            static public int AddNewInternationalLicense(int applicationID, int driverID,
                int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate,
                bool isActive, int createdByUserID)
            {
                int internationalLicenseID = -1;

                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = @"UPDATE InternationalLicenses
                                  SET IsActive = 0
                                WHERE DriverID = @driverID

                        INSERT INTO InternationalLicenses
                        (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, 
                         ExpirationDate, IsActive, CreatedByUserID)
                        VALUES
                        (@applicationID, @driverID, @issuedUsingLocalLicenseID, @issueDate,
                         @expirationDate, @isActive, @createdByUserID);
                         SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
                command.Parameters.AddWithValue("@expirationDate", expirationDate);
                command.Parameters.AddWithValue("@isActive", isActive);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        internationalLicenseID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return internationalLicenseID;
            }

            static public bool UpdateInternationalLicense(int internationalLicenseID, int applicationID,
                int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
                DateTime expirationDate, bool isActive, int createdByUserID)
            {
                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = @"UPDATE InternationalLicenses
                        SET ApplicationID = @applicationID,
                            DriverID = @driverID,
                            IssuedUsingLocalLicenseID = @issuedUsingLocalLicenseID,
                            IssueDate = @issueDate,
                            ExpirationDate = @expirationDate,
                            IsActive = @isActive,
                            CreatedByUserID = @createdByUserID
                        WHERE InternationalLicenseID = @internationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
                command.Parameters.AddWithValue("@applicationID", applicationID);
                command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
                command.Parameters.AddWithValue("@expirationDate", expirationDate);
                command.Parameters.AddWithValue("@isActive", isActive);
                command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }

            static public bool DeleteInternationalLicense(int internationalLicenseID)
            {
                int rowAffected = 0;

                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @internationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);

                try
                {
                    connection.Open();
                    rowAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return (rowAffected > 0);
            }

            static public DataTable GetAllInternationalLicenses()
            {
                DataTable dataTable = new DataTable();
                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = @"Select InternationalLicenseID , ApplicationID , DriverID , IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive
                                  From InternationalLicenses order by IsActive desc;";

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
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return dataTable;
            }
        public static DataTable GetAllInternationalLicensesOwnedByDriver (int driverID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select InternationalLicenseID , ApplicationID , IssuedUsingLocalLicenseID, IssueDate , ExpirationDate, IsActive
                                  From InternationalLicenses
                              Where InternationalLicenses.DriverID = @driverID;";

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
                // Log or handle exception
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
            static public bool IsInternationalLicenseExist(int internationalLicenseID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                string query = "SELECT Found = 1 FROM InternationalLicenses WHERE InternationalLicenseID = @internationalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);

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
                    // Log or handle exception
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }
        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            int internationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select top 1 InternationalLicenseID from InternationalLicenses 
                              Where DriverID = @driverID And IsActive = 1
							  and GETDATE() between IssueDate and ExpirationDate
							  order by ExpirationDate desc;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driverID", driverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString() , out int ID))
                {
                    internationalLicenseID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return internationalLicenseID;
        }
    }
}
