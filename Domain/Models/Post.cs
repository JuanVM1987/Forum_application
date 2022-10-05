namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public User Owner { get; }
    public Post(User owner,string title,  string body)
    {
        Title = title;
        Owner = owner;
        Body = body;
    }
}