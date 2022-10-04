namespace Domain.Models;

public class Post
{
    public int Id { get; }
    public string Title { get; set; }
    public User User { get; }
    public string Message { get; set; }

    public Post(string title, User user, string message)
    {
        Title = title;
        User = user;
        Message = message;
    }
}