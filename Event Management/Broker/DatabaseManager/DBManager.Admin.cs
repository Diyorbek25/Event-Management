
using Event_Management.Model;
using System.Data;
using System.Data.SqlClient;

namespace Event_Management.Broker.DatabaseManager;

public partial class DBManager : IDBManager
{
    public async Task AddRoomToDBAsync(Room room)
    {
        using var connection = new SqlConnection(connectionString);

        string query = $"execute [dbo].[InsertRoom]" +
            $"@name = {room.Name}, " +
            $"@number_of_places = {room.Number_Of_Places}";

        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();

        await command.ExecuteReaderAsync();
    }

    public async Task ChangeUserRoleAsync(int userId, Role role)
    {
        using var connection = new SqlConnection(connectionString);
        string query = $"UPDATE Users SET role = {(int)role} WHERE id = @userId;";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@userId", userId));
        
        await connection.OpenAsync();

        await command.ExecuteReaderAsync();
    }
    public async Task RemoveRoomFromDBAsync(Room room)
    {
        using var connection = new SqlConnection(connectionString);
        string query = $"DELETE FROM Places WHERE room_id = @roomId;" +
            $"\tDELETE FROM Rooms WHERE id = @roomId;";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@roomId", room.Id));

        await connection.OpenAsync();

        await command.ExecuteReaderAsync();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        using var connection = new SqlConnection(connectionString);
        string query = $"select * from Users where role = 2";

        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        List<User> users = new List<User>();

        while (reader.Read())
        {
           User newUser =  new User(
                user_Id: reader.GetInt32(0),
                full_Name: reader.GetString(1),
                user_Name: reader.GetString(2),
                password: reader.GetString(3),
                role: (Role)reader.GetInt32(4));
            users.Add(newUser);
        }
        return users;
    }
}
