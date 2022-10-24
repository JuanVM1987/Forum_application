using Application.DAOInterface;
using Application.LogicInterface;
using Domain.Models;

namespace Application.Logic;

public class AuthLogic:IAuthLogic
{
    private readonly IAuthDao _authDao;

    public AuthLogic(IAuthDao authDao)
    {
        _authDao = authDao;
    }

    public async Task<User> ValidateUserAsync(string username, string password)
    {
        User? check = await _authDao.ValidateUserAsync(username, password);
        if (check==null)
        {
            throw new Exception("User not found");
        }

        if (!check.Password.Equals(password))
        {
            throw new Exception("Password not correct");
        }

        return check;
    }
}