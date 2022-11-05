using Domain.DTOs;
using Domain.Models;

namespace Application.DAOInterface;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetByUsernameAndTitle(string username, string title);
    Task<IEnumerable<Post>> GrtAsync(SearchPostParametersDto dto);
    Task<Post?> GetByIdAsync(int id);
}