namespace Domain.Models;

public class User
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    

    public User(string username,string name, string surname,string password)
    {
        Username = username;
        Name = name;
        Password = password;
        Surname = surname;
    }
    
}