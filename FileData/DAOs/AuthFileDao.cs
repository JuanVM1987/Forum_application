using Application.DAOInterface;
using Domain.Models;

namespace FileData.DAOs;

public class AuthFileDao : IAuthDao
{
    
    private readonly FileContext _context;

    public AuthFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<User?> ValidateUserAsync(string username, string password)
    {
        User? check = _context.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(check);
    }
    
}