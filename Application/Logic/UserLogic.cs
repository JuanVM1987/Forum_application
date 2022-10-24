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
        User creating = new User(userCreateDto.UserName,userCreateDto.Email, userCreateDto.Password,2);
        User created= await _userDao.CreateAsync(creating);
        return created;
    }

    public async Task<IEnumerable<UserBasicDto>> GetAsync(SearchUserParametersDto parametersDto)
    {
        List<UserBasicDto> list = new List<UserBasicDto>();
        IEnumerable<User> users = await _userDao.GetAsync(parametersDto);
        users.ToList().ForEach(u=>list.Add(new UserBasicDto(u.Username,u.Email)));

        return list.AsEnumerable();
    }
}