using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterface;

public interface IUserLogic
{
    Task<UserBasicDto> CreateAsync(UserCreationDto userCreateDto);
    Task<IEnumerable<UserBasicDto>> GetAsync(SearchUserParametersDto parametersDto);
}