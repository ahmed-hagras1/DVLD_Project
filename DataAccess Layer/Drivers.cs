using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class Drivers
    {

        static public bool FindDriver(int driverID, ref int personID, ref int createdByUserID,
    ref DateTime createdDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @driverID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@driverID", driverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    personID = (int)reader["PersonID"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    createdDate = (DateTime)reader["CreatedDate"];

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
        static public bool FindDriverByPersonID(int personID ,ref int driverID,  ref int createdByUserID,
   ref DateTime createdDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @personID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    driverID = (int)reader["DriverID"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                    createdDate = (DateTime)reader["CreatedDate"];

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
        static public int AddNewDriver(int personID, int createdByUserID)
        {
            int driverID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                    VALUES (@personID, @createdByUserID, @createdDate);
                    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            command.Parameters.AddWithValue("@createdDate", DateTime.Now);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    driverID = insertedID;
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

            return driverID;
        }

        static public bool UpdateDriver(int driverID, int personID, int createdByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE Drivers
                    SET PersonID = @personID,
                        CreatedByUserID = @createdByUserID
                    WHERE DriverID = @driverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

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

        static public bool DeleteDriver(int driverID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "DELETE FROM Drivers WHERE DriverID = @driverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driverID", driverID);

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

        static public DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT * FROM Drivers_View order by Drivers_View.FullName;";

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

        static public bool IsDriverExist(int driverID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT 1 FROM Drivers WHERE DriverID = @driverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driverID", driverID);

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
        static public bool IsDriverExistByPersonID(int personID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT 1 FROM Drivers WHERE PersonID = @personID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

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

    }
}
