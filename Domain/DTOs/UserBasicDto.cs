namespace Domain.DTOs;

public class UserBasicDto
{
    public string UserName { get;}
    
    public string Email { get; }

    public UserBasicDto(string userName, string email)
    {
        UserName = userName;
       
        Email = email;
    }
}