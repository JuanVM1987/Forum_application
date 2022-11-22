namespace Domain.DTOs;

public class PostReturnDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    public string Body { get; set; }
    public string Owner { get; set; }
    public DateTime Created { get; set; }

    public PostReturnDto(int id, string title, string body, string owner, DateTime created)
    {
        Id = id;
        Title = title;
        Body = body;
        Owner = owner;
        Created = created;
    }
}