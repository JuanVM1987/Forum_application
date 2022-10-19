namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public int? PostId { get;  }
    public string? Title { get;  }
    public string? Owner { get;  }
    public DateTime? Created { get; }

    public SearchPostParametersDto(int? postId, string? title, string? owner, DateTime? created)
    {
        PostId = postId;
        Title = title;
        Owner = owner;
        Created = created;
    }
}