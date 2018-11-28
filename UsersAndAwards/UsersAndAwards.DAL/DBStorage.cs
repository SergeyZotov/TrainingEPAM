using Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UsersAndAwards.DAL
{
    public class DBStorage : IStorage
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public static readonly string providerName = ConfigurationManager.ConnectionStrings["MyConnectionString"].ProviderName;

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
                command.ExecuteNonQuery();
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

                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("Id", typeof(int)));

                foreach (var award in newUser.Awards)
                {
                    table.Rows.Add((int)award.AwardId);
                }

                command.Parameters.AddWithValue("@awardsIds", table).SqlDbType = SqlDbType.Structured;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void AddUserAwards(User user, SqlConnection connection)
        {
            DataTable awardsTable = new DataTable();
            awardsTable.Columns.Add("AwardId", typeof(int));

            foreach (var award in user.Awards)
            {
                awardsTable.Rows.Add((int)award.AwardId);
            }

            using (var command = new SqlCommand())
            {
                command.CommandText = "InsertUserRewards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Prepare();
                command.Parameters.AddWithValue("@userId", user.Id);
                command.Parameters.AddWithValue("@rewardIds", awardsTable).SqlDbType = SqlDbType.Structured;
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
                command.Parameters.AddWithValue("@awardId", currentAward.AwardId);
                command.Parameters.AddWithValue("@title", currentAward.Title);
                command.Parameters.AddWithValue("@description", currentAward.Description);
                connection.Open();
                command.ExecuteNonQuery();
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
                awards.Columns.Add(new DataColumn("AwardId", typeof(int)));
                command.Prepare();

                if (currentUser.Awards.Any())
                {
                    foreach (var aw in currentUser.Awards)
                    {
                        awards.Rows.Add(aw.AwardId);
                    }
                }
                else
                {
                    command.Parameters.AddWithValue("@awards", awards);
                }

                command.Parameters.AddWithValue("@userId", currentUser.Id);
                command.Parameters.AddWithValue("@fname", currentUser.FirstName);
                command.Parameters.AddWithValue("@lname", currentUser.LastName);
                command.Parameters.AddWithValue("@bdate", currentUser.Birthdate);
                connection.Open();
                command.ExecuteNonQuery();

                if (currentUser.Awards.Any())
                {
                    AddUserAwards(currentUser, connection);
                }
            }
        }

        public List<Award> GetAllAwards()
        {
            var listOfAwards = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "GetAwards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var award = new Award(reader.GetString(1), reader.GetString(2))
                        {
                            AwardId = reader.GetInt32(0)
                        };
                        listOfAwards.Add(award);
                    }
                }

                connection.Close();
            }
            return listOfAwards;
        }

        private void FillUsersAwards(List<User> users)
        {
            foreach (var user in users)
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    command.CommandText = "GetUserRewards";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Prepare();
                    command.Parameters.AddWithValue("@userId", user.Id);
                    connection.Open();
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var award = new Award(reader.GetString(1), reader.GetString(2))
                            {
                                AwardId = reader.GetInt32(0)
                            };
                            if (user.Awards.FirstOrDefault(aw => aw.AwardId == award.AwardId) != award)
                            {
                                user.Awards.Add(award);
                            }
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
                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new User(reader.GetString(1), reader.GetString(2), reader.GetDateTime(3))
                        {
                            Id = reader.GetInt32(0)
                        };
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
                command.Parameters.AddWithValue("@awardId", award.AwardId);
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
