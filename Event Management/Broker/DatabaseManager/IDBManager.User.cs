
using Event_Management.Model;

namespace Event_Management.Broker.DatabaseManager;

public partial interface IDBManager
{
    // Ro'yxatdan o'tish
    public Task<User> AddUserToDBAsync(User user);

    // Login
    public Task<User> GetUserDataDBAsync(string userName, string password);

    // Userni DB dan o'chirish
    public Task RemoveUserFromDBAsync(User user);

    // Trening uchun joy band qilish
    public Task AssignUsertoLocationAsync(int userId, Place place);

    // Eventlar ro'yxatini olish
    public Task<List<Event>> GetEventsAsync(int userId, Place place);

}
