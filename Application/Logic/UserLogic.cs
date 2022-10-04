using Application.DAOInterface;

namespace Application.Logic;

public class UserLogic
{
    private IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
}