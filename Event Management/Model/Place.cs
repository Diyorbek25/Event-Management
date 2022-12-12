
namespace Event_Management.Model;

public class Place
{
    public Place(int id, int room_Id, int? user_Id)
    {
        Id = id;
        Room_Id = room_Id;
        User_Id = user_Id;
    }

    public int Id { get; set; }
    public int Room_Id { get; set; }
    public int? User_Id { get; set; }
}
