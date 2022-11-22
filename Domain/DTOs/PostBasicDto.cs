namespace Domain.DTOs;

public class PostBasicDto
{
    public string Username { get; }
    public string Title { get; }
    public string Body { get; }

    public PostBasicDto(string username, string title, string body)
    {
        Username = username;
        Title = title;
        Body = body;
    }
}