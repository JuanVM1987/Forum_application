using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterface;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
}