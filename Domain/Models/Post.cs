using System.Globalization;

namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    public string Body { get; set; }
    public string Owner { get; }
    public DateTime Created { get; set; }
    
    public Post(string owner,string title,  string body)
    {
        Title = title;
        Owner = owner;
        Body = body;
    }
}