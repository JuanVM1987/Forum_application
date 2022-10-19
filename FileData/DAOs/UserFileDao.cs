using System.ComponentModel;
using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao:IUserDao
{
    private readonly FileContext _context;

    public UserFileDao(FileContext context)
    {
        this._context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? check = _context.Users.FirstOrDefault(u =>
                u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(check);
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parametersDto)
    {
        var users = _context.Users.AsEnumerable();
        
        if (parametersDto.UsernameContains!=null)
        {
            users = _context.Users.Where(u =>
                u.Username.Contains(parametersDto.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }
        
        return Task.FromResult(users);
    }
}