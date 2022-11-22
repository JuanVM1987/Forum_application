using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterface;

public interface IPostLogic
{
    Task<PostReturnDto> CreateAsync(PostBasicDto dto);
    Task<IEnumerable<PostReturnDto>> GetAsync(SearchPostParametersDto dto);
    Task<PostReturnDto?> GetByIdAsync(int id);
}