using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterface;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(int? postId, string? userName, string? title,DateTime? created);
}