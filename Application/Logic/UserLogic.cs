using System.Text.RegularExpressions;
using Application.DAOInterface;
using Application.Logic.Validators;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using Validator = System.ComponentModel.DataAnnotations.Validator;

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

        ValidatorData.ValidateDataUser(userCreateDto);
        User creating = new User
        {
            UserName = userCreateDto.UserName,
            Password = userCreateDto.Password
        };
        User created= await _userDao.CreateAsync(creating);
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parametersDto)
    {
        
    }
}