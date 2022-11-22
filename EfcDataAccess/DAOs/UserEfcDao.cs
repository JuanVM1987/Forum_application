using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao:IUserDao
{
    private readonly ForumContext _context;

    public UserEfcDao(ForumContext context)
    {
        _context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(userName.ToLower()) );

        return user;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto parametersDto)
    {
        IQueryable<User> usersQuery = _context.Users.AsQueryable();
        if (parametersDto.UsernameContains != null)
        {
            usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(parametersDto.UsernameContains.ToLower()));
        }

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }
}