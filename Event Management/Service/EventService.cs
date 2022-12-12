
using Event_Management.Broker.DatabaseManager;
using Event_Management.Model;

namespace Event_Management.Service;

public class EventService : IEventService
{
    private readonly IDBManager dBManager;

	public EventService(IDBManager dBManager)
	{
		this.dBManager = dBManager;
	}

	public async Task AssignUsertoLocationAsync(int userId, Place place)
	{
		await dBManager.AssignUsertoLocationAsync(userId, place);
	}

	public async Task ChangeUserRoleAsync(int userId, Role role)
	{
		await dBManager.ChangeUserRoleAsync(userId, role);
	}

	// Create Event
	public async Task<Event> CreateEventAsync(string name, DateTime createAt, int companyId, int roomId)
	{
		Event newEvent = new Event(name, createAt, companyId, roomId);
		Event createdEvent = await dBManager.AddEventToDBAsync(newEvent);
		return createdEvent;
	}

	public async Task CreateRoomAsync(string name, int numberOfPlaces)
	{
		Room newRoom = new Room(name, numberOfPlaces, null);
		await dBManager.AddRoomToDBAsync(newRoom);
	}

	public Task DeleteAccountAsync(int userId)
	{
		throw new NotImplementedException();
	}

	public async Task<List<Room>> GetEmptyRoomsAsync(int roomId)
	{
		var emptyRooms = await dBManager.GetEmptyRoomsAsync(roomId);
		return emptyRooms;
	}

	public async Task<List<Event>> GetEventAsync(int userId, Place place)
	{
		var events = await dBManager.GetEventsAsync(userId, place);
		return events;
	}

	public async Task<List<Room>> GetRoomsAsync(int roomId)
	{
		var rooms = await dBManager.GetRoomsAsync(roomId);
		return rooms;
	}

	public async Task<User> LoginAsync(string userName, string password)
	{
		var user = await dBManager.GetUserDataDBAsync(userName, password);
		return user;
	}

	public async Task<User> RegistrAsync(string fullName, string userName, string password)
	{
		User newUser = new User(fullName, userName, password);
		var createdUser = await dBManager.AddUserToDBAsync(newUser);
		return createdUser;
	}

	public async Task<List<Place>> StatisticPlace(int roomId)
	{
		var places = await dBManager.GetPlacesAsync(roomId);
		return places;
	}
}
