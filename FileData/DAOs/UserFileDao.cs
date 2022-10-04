using Application.DAOInterface;
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
                u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(check);
    }
}