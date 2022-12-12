
namespace Event_Management.Model;

public class Room
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Number_Of_Places { get; set; }
    public string? Event_Name { get; set; }

    public Room(string name, int number_Of_Places, string? event_Name)
    {
        Name = name;
        Number_Of_Places = number_Of_Places;
        Event_Name = event_Name;
    }

    public Room(int id, string name, int number_Of_Places, string? event_Name)
    {
        Id = id;
        Name = name;
        Number_Of_Places = number_Of_Places;
        Event_Name = event_Name;
    }
}
