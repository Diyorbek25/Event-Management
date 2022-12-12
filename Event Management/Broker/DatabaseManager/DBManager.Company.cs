
using Event_Management.Model;
using System.Data.SqlClient;

namespace Event_Management.Broker.DatabaseManager;

public partial class DBManager : IDBManager
{
    public async Task<List<Place>> GetPlacesAsync(int roomId)
    {
        using var connection = new SqlConnection(connectionString);

        string query = $"execute [dbo].[GetPlaces] " +
            $"@room_id = @roomId";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@roomId", roomId));
        
        await connection.OpenAsync();   

        SqlDataReader reader = await command.ExecuteReaderAsync();
        List<Place> places = new List<Place>();

        while (reader.Read())
        {
            Place place = new Place(
                id: reader.GetInt32(0),
                room_Id: reader.GetInt32(1),
                user_Id: reader.GetInt32(2));
            places.Add(place);
        }
        return places;
    }

    public async Task<List<Room>> GetRoomsAsync(int roomId)
    {
        using var connection = new SqlConnection(connectionString);

        string query = $"execute [dbo].[GetRooms] " +
            $"@room_id = @roomId";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@roomId", roomId));

        await connection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        List<Room> rooms = new List<Room>();

        while (reader.Read())
        {
            Room room = new Room(
                id: reader.GetInt32(0),
                name: reader.GetString(1),
                number_Of_Places: reader.GetInt32(2),
                event_Name: reader.GetString(3));
            rooms.Add(room);
        }
        return rooms;
    }
    public async Task<List<Room>> GetEmptyRoomsAsync(int roomId)
    {
        using var connection = new SqlConnection(connectionString);

        string query = $"execute [dbo].[GetEmptyRooms];";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@roomId", roomId));

        await connection.OpenAsync();

        SqlDataReader reader = await command.ExecuteReaderAsync();
        List<Room> rooms = new List<Room>();

        while (reader.Read())
        {
            Room room = new Room(
                id: reader.GetInt32(0),
                name: reader.GetString(1),
                number_Of_Places: reader.GetInt32(2),
                event_Name: reader.GetString(3));
            rooms.Add(room);
        }
        return rooms;
    }

    public Task<Event> AddEventToDBAsync(Event newEvent)
    {
        throw new Exception();
    }
}
