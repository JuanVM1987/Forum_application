namespace Domain.DTOs;

public class SerchPostParametersDto
{
    public int? PostId { get;  }
    public string? Title { get;  }
    public string? Owner { get;  }
    public DateTime? Created { get; }

    public SerchPostParametersDto(int? postId, string? title, string? owner, DateTime? created)
    {
        PostId = postId;
        Title = title;
        Owner = owner;
        Created = created;
    }
}