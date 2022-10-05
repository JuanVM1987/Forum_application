using Application.DAOInterface;
using Application.Logic.Validators;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic:IUserLogic
{
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userCreateDto)
    {
        User? check = await _userDao.GetByUsernameAsync(userCreateDto.UserName);
        if (check!=null)
        {
            throw new Exception($"¡{userCreateDto.UserName} Already Exist!");
        }

        ValidatorUserData.ValidateDataUser(userCreateDto);
        User creating = new User(userCreateDto.UserName, userCreateDto.Password);
        User created= await _userDao.CreateAsync(creating);
        return created;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parametersDto)
    {
        List<User> list = new List<User>();
        IEnumerable<User> users = await _userDao.GetAsync(parametersDto);
        
        //hide password
        users.ToList().ForEach(u=>list.Add(new User(u.Username,u.Password="*****")));

        return list.AsEnumerable();
    }
}