using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace UsersAndAwards.DAL
{
    public class DBStorage : IStorage
    {
        private readonly string connectionString = string.Empty;

        public static readonly string connection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public static readonly string providerName = ConfigurationManager.ConnectionStrings["MyConnectionString"].ProviderName;

        public DBStorage(string connection)
        {
            connectionString = connection; //ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public void AddAward(Award newAward)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@title", newAward.Title);
                command.Parameters.AddWithValue("@description", newAward.Description);

                connection.Open();

                var result = command.ExecuteScalar();
                //var newAwardId = (int)result;
                //newAward.Id = newAwardId;
            }
        }

        public void AddUser(User newUser)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@fname", newUser.FirstName);
                command.Parameters.AddWithValue("@lname", newUser.LastName);
                command.Parameters.AddWithValue("@bdate", newUser.Birthdate);

                connection.Open();

                var result = command.ExecuteReader();
                // var userId = (int)result;
                //newUser.Id = result.GetInt32(0);

                AddUserAwards(newUser, connection);

            }
        }

        private void AddUserAwards(User user, SqlConnection connection)
        {
            DataTable awardsTable = new DataTable();
            awardsTable.Columns.Add("AwardId", typeof(int));
            foreach(var award in user.GetAwards())
            {
                awardsTable.Rows.Add(award.Id);
            }

            using (var command = new SqlCommand())
            {
                command.CommandText = "InsertUserRewards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Prepare();
                command.Parameters.AddWithValue("@userId", user.Id);
              /* var awardsTablePArameter = */command.Parameters.AddWithValue("@rewardIds", awardsTable);
                //awardsTablePArameter.SqlDbType = SqlDbType.Structured;

                command.ExecuteNonQuery();
            }
        }

        public void EditAward(Award currentAward, int row)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "EditAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@awardId", row);
                command.Parameters.AddWithValue("@title", currentAward.Title);
                command.Parameters.AddWithValue("@description", currentAward.Description);

                connection.Open();

                /*var result = */command.ExecuteScalar();
                /*var currentAwardId = (int)result;
                currentAward.Id = currentAwardId;*/

            }
        }

        public void EditUser(User currentUser, int row)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "EditUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                DataTable awards = new DataTable();
                awards.Columns.Add("AwardId", typeof(int));
                currentUser.awards =  currentUser.awards.Distinct().ToList();
                if (currentUser.awards.Any())
                {
                    foreach (var aw in currentUser.awards)
                    {
                        if (aw.Id == 0)
                            continue;
                        awards.Rows.Add(aw.Id);
                    }

                }


                command.Prepare();
                command.Parameters.AddWithValue("@userId", row);
                command.Parameters.AddWithValue("@fname", currentUser.FirstName);
                command.Parameters.AddWithValue("@lname", currentUser.LastName);
                command.Parameters.AddWithValue("@bdate", currentUser.Birthdate);
                command.Parameters.AddWithValue("@awards", awards);

                connection.Open();

                /*var result = */

                command.ExecuteNonQuery();
                /*var userId = (int)result;
                currentUser.Id = userId;*/

                //AddUserAwards(currentUser, connection);

            }
        }

        public List<Award> GetAllAwards()
        {
            var awards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                /*command.CommandText = "GetAwards";
                command.CommandType = CommandType.StoredProcedure;*/
                command.CommandText = "SELECT [Id], [Title], [Description] FROM Awards";

                command.Connection = connection;

                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var award = new Award(reader.GetString(1), reader.GetString(2));
                        awards.Add(award);
                    }
                }

                connection.Close();
            }
            return awards;
        }

        private void FillUsersAwards(List<User> users)
        {
            foreach (var user in users)
            {
                user.awards = new List<Award>();
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    command.CommandText = "GetUserRewards";
                    command.CommandType = CommandType.StoredProcedure;
                    /*command.CommandText = "	SELECT Awards.Id, [Title], [Description], Relations.UserId, Relations.AwardId" +

                    "FROM Awards INNER JOIN Relations ON Relations.UserId = AwardId" +

                    "WHERE Relations.UserId = @userId";*/
                    command.Connection = connection;
                    command.Prepare();
                    command.Parameters.AddWithValue("@userId", user.Id);

                    connection.Open();

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var award = new Award(reader.GetString(1), reader.GetString(2));
                            award.Id = reader.GetInt32(0);
                            user.awards.Add(award);
                        }
                    }

                    connection.Close();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "GetUsers";
                command.CommandType = CommandType.StoredProcedure;
                //command.CommandText = "SELECT [Id], [First Name], [Last Name], [Birthdate] FROM Users";
                command.Connection = connection;

                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new User(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                        user.Id = reader.GetInt32(0);
                        users.Add(user);
                    }
                }

                connection.Close();
            }
            FillUsersAwards(users);
            return users;
        }

        public bool RemoveAward(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "DeleteAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@awardId", award.Id);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }

        public bool RemoveUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@userId", user.Id);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return true;
        }
    }
}
