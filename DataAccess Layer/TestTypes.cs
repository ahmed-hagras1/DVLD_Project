using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer
{
    public static class TestTypes
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable testTypesTable = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "SELECT * FROM TestTypes;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    testTypesTable.Load(reader);
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

            return testTypesTable;
        }

        public static bool UpdateTestType(int testTypeID, string testTypeTitle, string testTypeDescription, float testFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"UPDATE TestTypes
                              SET TestTypeTitle = @testTypeTitle
                                 ,TestTypeDescription = @testTypeDescription
                                 ,TestTypeFees = @testFees
                             WHERE TestTypeID = @testTypeID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testTypeTitle", testTypeTitle);
            command.Parameters.AddWithValue("@testTypeDescription", testTypeDescription);
            command.Parameters.AddWithValue("@testFees", testFees);
            command.Parameters.AddWithValue("@testTypeID", testTypeID);

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
        public static int AddNewTestType(string testTypeTitle,string testTypeDescription ,float testFees)
        {
            int testTypeID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"INSERT INTO TestTypes
                             (TestTypeTitle,TestTypeDescription,TestTypeFees)
                       VALUES (@testTypeTitle , @testTypeDescription, @testTypeFees);
                  SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testTypeTitle", testTypeTitle);
            command.Parameters.AddWithValue("@testTypeDescription", testTypeDescription);
            command.Parameters.AddWithValue("@testTypeFees", testFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    testTypeID = insertedID;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return testTypeID;
        }
        public static bool FindTestTypeByID(int testTypeID, ref string testTypeTitle,ref string testTypeDescription, ref float testTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @testTypeID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    testTypeTitle = (string)reader["TestTypeTitle"];
                    testTypeDescription = (string)reader["TestTypeDescription"];
                    testTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
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
        public static bool IsTestTypeExist(int testTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select found = 1 from TestTypes where TestTypeID = @testTypeID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@testTypeID", testTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    isFound = true;
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
