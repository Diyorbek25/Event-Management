
using Event_Management.Model;

namespace Event_Management.Broker.DatabaseManager;

public partial interface IDBManager
{
    // User ro'lini o'zgartirish
    public Task ChangeUserRoleAsync(int userId, Role role);

    // Xona yaratish
    public Task AddRoomToDBAsync(Room room);

    // Xona o'chirish
    public Task RemoveRoomFromDBAsync(Room room);
}
