namespace Domain.Models;

public class User
{
    public string Username { get; set; }
   
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int SecurityLevel { get; set; }
    

    public User(string username,string email,string password, int securityLevel)
    {
        Username = username;
        Password = password;
        SecurityLevel = securityLevel;
        Email = email;
    }
    
}