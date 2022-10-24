using Domain.Models;

namespace Application.DAOInterface;

public interface IAuthDao
{
    Task<User?> ValidateUserAsync(string username, string password);

}