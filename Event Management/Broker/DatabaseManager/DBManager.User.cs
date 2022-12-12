
using Event_Management.Model;
using System;
using System.Data.SqlClient;

namespace Event_Management.Broker.DatabaseManager;

public partial class DBManager : IDBManager
{
    private string connectionString = @"Server=(localdb)\mssqllocaldb; Database=EventManagement;";

    public async Task<User> AddUserToDBAsync(User user)
    {
        using var connection = new SqlConnection(connectionString);

        string query = $"execute [dbo].[InsertUser] " +
            $"@fullName = {user.Full_Name}, " +
            $"@userName = {user.User_Name}, " +
            $"@password = {user.GetPassword()}";
        
        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        User newUser = null;

        while (reader.Read())
        {
            new User(
                user_Id: reader.GetInt32(0),
                full_Name: reader.GetString(1),
                user_Name: reader.GetString(2),
                password: reader.GetString(3),
                role: (Role)reader.GetInt32(4));
        }
        return newUser;
    }

    public async Task<User> GetUserDataDBAsync(string userName, string password)
    {
        using var connection = new SqlConnection(connectionString);
        string query = $"select * from Users where user_name = @userName and password = @password";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@userName", userName));
        command.Parameters.Add(new SqlParameter("@password", password));

        await connection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        User user = null;

        while (reader.Read())
        {
            new User(
                user_Id: reader.GetInt32(0),
                full_Name: reader.GetString(1),
                user_Name: reader.GetString(2),
                password: reader.GetString(3),
                role: (Role)reader.GetInt32(4));
        }
        return user;
    }


    public Task AssignUsertoLocationAsync(int userId, Place place)
    {
        throw new NotImplementedException();
    }

    

    public Task<List<Event>> GetEventsAsync(int userId, Place place)
    {
        throw new NotImplementedException();
    }


    public Task RemoveUserFromDBAsync(User user)
    {
        throw new NotImplementedException();
    }
}
