using WODWarriors.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WODWarriors.Data
{
    public class UserDataStore
    {
        private readonly string _databasePath;

        public UserDataStore()
        {
            _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT NOT NULL, Email TEXT NOT NULL, Password TEXT NOT NULL);";
            command.ExecuteNonQuery();
        }
        public async Task<bool> RegisterUserAsync(User user)
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password);";
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            return await command.ExecuteNonQueryAsync() > 0;
        }
        //EDIT USERDELETE
        public async Task<bool> DeleteUserAsync(int userId)
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Users WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", userId);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
        //public async Task<bool> EditUserAsync(int userId, string newUsername, string newEmail)
        //{
        //    using var connection = new SqliteConnection($"Data Source={_databasePath}");
        //    await connection.OpenAsync();
        //    using var command = connection.CreateCommand();
        //    command.CommandText = "UPDATE Users SET Username = @Username, Email = @Email WHERE Id = @Id;";
        //    command.Parameters.AddWithValue("@Username", newUsername);
        //    command.Parameters.AddWithValue("@Email", newEmail);
        //    command.Parameters.AddWithValue("@Id", userId);

        //    int rowsAffected = await command.ExecuteNonQueryAsync();
        //    return rowsAffected > 0;
        //}
        //FOR USER DELETE PAGE
        public async Task<List<User>> GetAllUsersAsync()
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users;";
            using var reader = await command.ExecuteReaderAsync();

            var users = new List<User>();
            while (await reader.ReadAsync())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3)
                });
            }

            return users;
        }


        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            await connection.OpenAsync();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password;";
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3)
                };
            }

            return null;
        }

        
    }
}
