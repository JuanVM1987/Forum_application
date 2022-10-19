using System.Globalization;
using Application.DAOInterface;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao:IPostDao
{
    private readonly FileContext _context;

    public PostFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (_context.Posts.Any())
        {
            id = _context.Posts.Max(o => o.Id);
            id++;
        }
        post.Created=DateTime.Now;
        post.Id = id;
        _context.Posts.Add(post);
        _context.SaveChanges();
        return Task.FromResult(post);

    }

    public Task<Post?> GetByUsernameAndTitle(string username, string title)
    {
        Post? existing = _context.Posts.FirstOrDefault(p =>
            p.Owner.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GrtAsync(SearchPostParametersDto dto)
    {
        IEnumerable <Post> result = _context.Posts.AsEnumerable();
        
        if (!string.IsNullOrEmpty(dto.Owner))
        {
            result = _context.Posts.Where(post => post.Owner.Equals(dto.Owner, StringComparison.OrdinalIgnoreCase));
        }

        if (dto.PostId!=null)
        {
            result = result.Where(id => id.Id == dto.PostId);
        }

        if (!string.IsNullOrEmpty(dto.Title))
        {
            result = result.Where(o => o.Title.Contains(dto.Title, StringComparison.OrdinalIgnoreCase));

        }

        if (dto.Created !=null)
        {
            result = result.Where(d => d.Created.Date == dto.Created.Value.Date);
        }

        return Task.FromResult(result);
    }
}