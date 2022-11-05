using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterface;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(int? postId, string? owner, string? title,DateTime? created);
    Task<Post>GetByIdAsync(int id);
    
}