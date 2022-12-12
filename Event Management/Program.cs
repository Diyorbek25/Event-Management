using Event_Management.Broker.DatabaseManager;
using Event_Management.Service;
using Event_Management.View;

namespace Event_Management;

internal class Program
{
    static async Task Main(string[] args)
    {
        IDBManager dBManager = new DBManager();
        IEventService eventService = new EventService(dBManager);
        MainView mainView = new MainView(eventService);

        await mainView.UserMenu();
    }
}