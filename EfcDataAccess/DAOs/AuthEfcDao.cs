using Application.DAOInterface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess.DAOs;

public class AuthEfcDao:IAuthDao
{
    private readonly ForumContext _context;

    public AuthEfcDao(ForumContext context)
    {
        _context = context;
    }

    public async Task<User?> ValidateUserAsync(string username, string password)
    {
        User? check = await _context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(username.ToLower()));

        return check;

    }
}