
using Event_Management.Model;

namespace Event_Management.Service;

public interface IEventService
{
    // User ro'yxatdan o'tish
    public Task<User> RegistrAsync(string fullName, string userName, string password);

    // Login
    public Task<User> LoginAsync(string userName, string password);

    // Eventlar ro'yxati
    public Task<List<Event>> GetEventAsync(int userId, Place place);

    // Remove USer
    public Task DeleteAccountAsync(int userId);

    // Bo'sh xonalar ro'yxati
    public Task<List<Room>> GetEmptyRoomsAsync(int roomId);

    // Xonalar ro'yxati
    public Task<List<Room>> GetRoomsAsync(int roomId);

    //Joy statistiaksi
    public Task<List<Place>> StatisticPlace(int roomId);

    // Create Event
    public Task<Event> CreateEventAsync(string name, DateTime createAt, int companyId, int roomId);

    // Joy band qilish
    public Task AssignUsertoLocationAsync(int userId, Place place);

    // Creaate Room
    public Task CreateRoomAsync(string name, int numberOfPlaces);

    // User rolini o'zgartish
    public Task ChangeUserRoleAsync(int userId, Role role);
}
