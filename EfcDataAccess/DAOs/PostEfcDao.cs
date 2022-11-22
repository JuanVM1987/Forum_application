using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao:IPostDao
{
    private readonly ForumContext _context;

    public PostEfcDao(ForumContext context)
    {
        _context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return newPost.Entity;
    }

    public Task<Post?> GetByUsernameAndTitle(string username, string title)
    {

        var queryable = _context.Posts.Where(x => x.Owner.Username.Equals(username) && x.Title.ToLower().Equals(title.ToLower()));
        Post? post = queryable.FirstOrDefault(u => u.Owner.Username == username);
        return Task.FromResult(post);

    }

    public async Task<IEnumerable<Post>> GrtAsync(SearchPostParametersDto dto)
    {
        IQueryable<Post> posts = _context.Posts.Include(u=>u.Owner).AsQueryable();

        if (dto.PostId!=null)
        {
            posts = posts.Where(u => u.Id == dto.PostId);
        }

        if (!string.IsNullOrEmpty(dto.Title))
        {
            posts = posts.Where(u => u.Title.Contains(dto.Title));
        }

        if (!string.IsNullOrEmpty(dto.Owner))
        {
            posts = posts.Where(u => u.Owner.Username == dto.Owner);
        }

        if (dto.Created!=null)
        {
            posts = posts.Where(u => u.Created.Date == dto.Created);
        }
        
        IEnumerable<Post> result = await posts.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? post = await _context.Posts.Include(u => u.Owner).FirstOrDefaultAsync(p => p.Id == id);

        return post;
    }
}