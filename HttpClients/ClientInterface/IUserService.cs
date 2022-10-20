using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterface;

public interface IUserService
{
    Task<User> RegisterAsync(UserCreationDto dto);
    Task<IEnumerable<UserBasicDto>> GetUsersAsync(string? usernameContains = null);

}