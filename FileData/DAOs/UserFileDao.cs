using System.ComponentModel;
using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao:IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? check = context.Users.FirstOrDefault(u =>
                u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(check);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parametersDto)
    {
        var users = context.Users.AsEnumerable();
        
        if (parametersDto.UsernameContains!=null)
        {
            users = context.Users.Where(u =>
                u.Username.Contains(parametersDto.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }
        
        return Task.FromResult(users);
    }
}