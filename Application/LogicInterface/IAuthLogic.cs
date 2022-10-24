using Domain.Models;

namespace Application.LogicInterface;

public interface IAuthLogic
{
    Task<User> ValidateUserAsync(string username, string password);
}