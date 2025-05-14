using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class Users
    {

        static public bool FindUserByUserID(int userID, ref int personID, ref string username,
            ref string password, ref bool isActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * from Users where userID  = @userID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    personID = (int)reader["personID"];
                    username = (string)reader["username"];
                    password = (string)reader["password"];
                    isActive = (bool)reader["isActive"];
                   
                    isFound = true;
                }

                reader.Close();
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
        static public bool FindUserByPersonID( int personID,ref int userID, ref string username,
            ref string password, ref bool isActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * from Users where personID  = @personID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userID = (int)reader["userID"];
                    username = (string)reader["username"];
                    password = (string)reader["password"];
                    isActive = (bool)reader["isActive"];

                    isFound = true;
                }

                reader.Close();
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

        static public bool FindUserByUsernameAndPassword(string username, string password, ref int userID, ref int personID, 
              ref bool isActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * from Users where username  = @username and password = @password";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userID = (int)reader["userID"];
                    personID = (int)reader["personID"];
                    isActive = (bool)reader["isActive"];

                    isFound = true;
                }

                reader.Close();
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
        static public int AddNewUser( int personID,  string username,
             string password,  bool isActive)
        {
            int userID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO Users
                             (PersonID,UserName,Password,IsActive)
                                 VALUES(@personID , @username , @password , @isActive);
                                  Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isActive", isActive);
            

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    userID = insertedID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return userID;
        }

        static public bool UpdateUser(int userID,int personID, string username,
             string password, bool isActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE Users
                             SET PersonID = @personID
                                ,UserName = @username
                                ,Password = @password
                                ,IsActive = @isActive
                           WHERE UserID = @userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isActive", isActive);

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

        static public bool DeleteUser(int userID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"DELETE FROM Users
                              WHERE userID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }
        static public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select UserID , Users.PersonID , (FirstName + ' ' + SecondName + ' ' + ISNULL(ThirdName, '') + ' ' + LastName) as fullName,
                              UserName , IsActive
                              from Users
                              inner join People on People.PersonID = Users.PersonID;";

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

            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
        static public bool IsUserExist(int userID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from Users where userID = @userID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);

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

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool IsUserExist(string username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from Users where username = @username;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);

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

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool IsUserExistByPersonID(int personID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from Users where personID = @personID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

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

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool ChangeUserPassword(int userID , string newPassword)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE Users
                              SET 
                                 Password = @password
                            WHERE UserID = @userID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@password", newPassword);
            command.Parameters.AddWithValue("@userID", userID);

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
    }
}
