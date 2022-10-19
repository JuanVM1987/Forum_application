namespace Domain.DTOs;

public class UserBasicDto
{
    public string UserName { get;}
    public string Name { get;}
    public string Surname { get; }

    public UserBasicDto(string userName, string name, string surname)
    {
        UserName = userName;
        Name = name;
        Surname = surname;
    }
}