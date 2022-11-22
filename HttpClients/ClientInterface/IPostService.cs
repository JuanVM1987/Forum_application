using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterface;

public interface IPostService
{
    Task CreateAsync(PostBasicDto dto);
    Task<ICollection<PostReturnDto>> GetAsync(int? postId, string? owner, string? title,DateTime? created);
    Task<PostReturnDto>GetByIdAsync(int id);
    
}