
using Event_Management.Model;
using Event_Management.Service;

namespace Event_Management.View;

public class MainView
{
	private IEventService eventService;
	private User currentUser = null;

	public MainView(IEventService eventService)
	{
		this.eventService = eventService;
	}


	public async Task UserMenu()
	{
		Console.WriteLine("1. Registr");
		Console.WriteLine("2. Login");
		Console.Write(">> ");

		if (!int.TryParse(Console.ReadLine(), out int item))
		{
			Console.Clear();
			await UserMenu();
			return;
		}
		switch (item)
		{
			case 1:
				{
					Console.Write("Full Name: ");
					string fullName = Console.ReadLine();
					Console.Write("Username: ");
					string userName = Console.ReadLine();
					Console.Write("Password: ");
					string password = Console.ReadLine();

					currentUser = await eventService.RegistrAsync(fullName, userName, password);
				} break;
			case 2:
				{
					Console.Write("UserName: ");
					string userName = Console.ReadLine();
					Console.Write("Password: ");
					string password = Console.ReadLine();

					currentUser = await eventService.LoginAsync(userName, password);

				} break;
			default:
				{
					Console.Clear();
					await UserMenu();
					return;
				}
		}
	}

	public async Task AdminMenu()
	{
		Console.WriteLine("1. Create Room");
		Console.WriteLine("2. Setting the User role");
		Console.WriteLine("3. Delete Room");
		Console.WriteLine("4. Room name change");

		if (!int.TryParse(Console.ReadLine(), out int item))
		{
			Console.Clear();
			await AdminMenu();
			return;
		}
		switch (item)
		{
			case 1:
				{
					Console.Write("Name: ");
					string name = Console.ReadLine();
					Console.Write("Number of place in the room: ");
					if (!int.TryParse(Console.ReadLine(), out int numberOdPlaces))
					{
                        Console.Clear();
                        await AdminMenu();
                        return;
                    }
					await eventService.CreateRoomAsync(name, numberOdPlaces);
					Console.Clear();
					Console.WriteLine("Create succesfull");
					await AdminMenu();
					return;
				} break;
			case 2:
				{
					Console.WriteLine("1. Company");
                    if (!int.TryParse(Console.ReadLine(), out int roleId) && roleId != 1)
                    {
                        Console.Clear();
                        await AdminMenu();
                        return;
                    }
					await eventService.ChangeUserRoleAsync()
                } break;
			case 3:
				{

				} break;
			case 4:
				{

				} break;
			default:
				{
                    Console.Clear();
                    await AdminMenu();
                    return;
                }
		}
	}
}
