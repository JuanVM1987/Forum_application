namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get;}
    public string Name { get;}
    public string Surname { get; }
    public string Password { get; }

    public UserCreationDto(string userName, string name, string surname, string password)
    {
        UserName = userName;
        Password = password;
        Surname = surname;
        Name = name;
    }
}