
namespace Event_Management.Model;

public class Event
{

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Event_Date { get; set; }
    public int Company_Id { get; set; }
    public int Room_Id { get; set; }

    public Event(string name, DateTime event_Date, int company_Id, int room_Id)
    {
        Name = name;
        Event_Date = event_Date;
        Company_Id = company_Id;
        Room_Id = room_Id;
    }
}
