using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public class PeopleDataAccess
    {
        static public bool FindPerson(string nationalNum, ref int personID, ref string firstName,
            ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth,
            ref byte gender, ref string address, ref string phone, ref string email,
            ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * from People where Nationalno = @nationalNum";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationalNum", nationalNum);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    personID = (int)reader["PersonID"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        thirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thirdName = "";
                    }
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gender"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }

                    nationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imagePath = "";
                    }

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
        static public bool FindPerson(int personID , ref string nationalNum, ref string firstName ,
            ref string secondName , ref string thirdName , ref string lastName , ref DateTime dateOfBirth ,
            ref byte gender , ref string address , ref string phone, ref string email ,
            ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "Select * from People where PersonID  = @personID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() )
                {
                    nationalNum = (string)reader["NationalNo"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    // ThirdName: allows null in database so we should handule null.
                    if (reader["ThirdName"] != DBNull.Value )
                    {
                        thirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thirdName = "";
                    }
                    lastName = (string)reader["LastName"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gender"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value )
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }

                     nationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value )
                    {
                        imagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        imagePath = "";
                    }

                    isFound = true;
                }

                reader.Close();
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

        static public int AddNewPerson(string nationalNum,  string firstName,
            string secondName,  string thirdName,  string lastName,  DateTime dateOfBirth,
            byte gender,  string address,  string phone,  string email,
            int nationalityCountryID,  string imagePath)
        {
            int personID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO People
                              (NationalNo,FirstName,SecondName,ThirdName,LastName,
		                      DateOfBirth,Gender,Address,Phone,
		                      Email,NationalityCountryID,ImagePath)
                               VALUES
                               (@nationalNo , @firstName , @secondName, @thirdName , @lastName,
                                 @dateOfBirth,@gender , @address , @phone,
                                 @email, @nationalityCountryID , @imagePath);
                                  Select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationalNo", nationalNum);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@secondName", secondName);

            if (thirdName != "")
            {
                command.Parameters.AddWithValue("@thirdName", thirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@thirdName", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);

            if (email != "")
            {
                command.Parameters.AddWithValue("@email", email);
            }
            else
            {
                command.Parameters.AddWithValue("@email", System.DBNull.Value);
            }
            
            command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID);

            if (imagePath != "")
            {
                command.Parameters.AddWithValue("@imagePath", imagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@imagePath", System.DBNull.Value);
            }
            

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString() , out int insertedID))
                {
                    personID = insertedID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return personID;
        }

        static public bool UpdatePerson( int personID, string nationalNum, string firstName,
             string secondName, string thirdName, string lastName, DateTime dateOfBirth,
             byte gender, string address, string phone, string email,
             int nationalityCountryID, string imagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE People
                              SET NationalNo = @nationalNo
                                 ,FirstName = @firstName
                                 ,SecondName = @secondName
                                 ,ThirdName = @thirdName
                                 ,LastName = @lastName
                                 ,DateOfBirth = @dateOfBirth
                                 ,Gender = @gender
                                 ,Address = @address
                                 ,Phone = @phone
                                 ,Email =@email
                                 ,NationalityCountryID = @nationalityCountryID
                                 ,ImagePath = @imagePath
                                   WHERE  PersonID = @personID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@nationalNo", nationalNum);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@secondName", secondName);

            if (thirdName != "")
            {
                command.Parameters.AddWithValue("@thirdName", thirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@thirdName", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);

            if (email != "")
            {
                command.Parameters.AddWithValue("@email", email);
            }
            else
            {
                command.Parameters.AddWithValue("@email", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID);

            if (imagePath != "")
            {
                command.Parameters.AddWithValue("@imagePath", imagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@imagePath", System.DBNull.Value);
            }


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

            return (rowsAffected > 0 );
        }

        static public bool DeletePerson(int personID)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"DELETE FROM People
                              WHERE PersonID = @personID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }
        static public DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT People.PersonID, People.NationalNo,
              People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			  People.DateOfBirth, People.Gender,  
				  CASE
                  WHEN People.Gender = 0 THEN 'Male'

                  ELSE 'Female'

                  END as GenderCaption ,
			  People.Address, People.Phone, People.Email, 
              People.NationalityCountryID, Countries.CountryName, People.ImagePath
              FROM            People INNER JOIN
                         Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY People.FirstName;";

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
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
        static public bool IsPersonExist(int personID )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from People where PersonID = @personID;";
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
            catch (Exception ex )
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool IsPersonExist(string nationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from People where NationalNo = @nationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);

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

    }
}
