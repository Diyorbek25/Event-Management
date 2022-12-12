
namespace Event_Management.Model;

public class User
{
    public int User_Id { get; set; }
    public string Full_Name { get; set; }
    public string User_Name { get; set; }

    private string Password { get; set; }
    public Role Role { get; set; }

    public User(string full_Name, string user_Name, string password)
    {
        Full_Name = full_Name;
        User_Name = user_Name;
        Password = password;
    }

    public User(int user_Id, string full_Name, string user_Name, string password, Role role)
    {
        User_Id = user_Id;
        Full_Name = full_Name;
        User_Name = user_Name;
        Password = password;
        Role = role;
    }

    public string GetPassword() => this.Password;
}


