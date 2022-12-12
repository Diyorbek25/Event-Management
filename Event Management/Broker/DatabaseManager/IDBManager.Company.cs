
using Event_Management.Model;

namespace Event_Management.Broker.DatabaseManager;

public partial interface IDBManager
{
    // Bo'sh Xonalar ro'yxatini olish
    public Task<List<Room>> GetEmptyRoomsAsync(int roomId);

    // Umumiy xonalar ro'yxatini olish
    public Task<List<Room>> GetRoomsAsync(int roomId);

    // Joylar ro'yxatini olish
    public Task<List<Place>> GetPlacesAsync(int roomId);

    // Add Event
    public Task<Event> AddEventToDBAsync(Event newEvent);

    // get All Users
    public  Task<List<User>> GetUsersAsync();
}
