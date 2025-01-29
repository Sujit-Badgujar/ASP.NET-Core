using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;          //Data.SqlClient;
using CrudeApp_Paramount.Models;

namespace CrudeApp_Paramount.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ManageUser(User user, char flag)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("ManageUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Flag", flag); //like- i, u, d
                        command.Parameters.AddWithValue("@UserId", user.UserId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();

            try     //Also kept try catch for exception handling.
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT * FROM Users";  //to get all users from GET request
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserId = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

            return users;
        }
    }
}

#region Commented Code
//using System;
//using System.Collections.Generic;
//using System.Data;
//using Microsoft.Data.SqlClient;          //Data.SqlClient;
//using CrudeApp_Paramount.Models;

//namespace CrudeApp_Paramount.Services
//{
//    public class DatabaseService
//    {

//        private readonly string _connectionString;

//        public DatabaseService(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public void ManageUser(User user, char flag)
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                using (var command = new SqlCommand("ManageUsers", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@Flag", flag);
//                    command.Parameters.AddWithValue("@UserId", user.UserId ?? (object)DBNull.Value);
//                    command.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
//                    command.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
//                    command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);

//                    connection.Open();
//                    command.ExecuteNonQuery();
//                }
//            }
//        }

//        public List<User> GetUsers()
//        {
//            var users = new List<User>();

//            using (var connection = new SqlConnection(_connectionString))
//            {
//                var query = "SELECT * FROM Users";
//                using (var command = new SqlCommand(query, connection))
//                {
//                    connection.Open();
//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            users.Add(new User
//                            {
//                                UserId = reader.GetInt32(0),
//                                FirstName = reader.GetString(1),
//                                LastName = reader.GetString(2),
//                                Email = reader.GetString(3)
//                            });
//                        }
//                    }
//                }
//            }

//            return users;
//        }

//    }
//}
#endregion
