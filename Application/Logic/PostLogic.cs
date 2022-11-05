using Application.DAOInterface;
using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    private readonly IPostDao _postDao;
    private readonly IUserDao _userDao;
    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        _postDao = postDao;
        _userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? checkUser = await _userDao.GetByUsernameAsync(dto.Username);
        if (checkUser == null)
            throw new Exception($"Username: {dto.Username} was not found.");
        
        Post? check = await _postDao.GetByUsernameAndTitle(dto.Username, dto.Title);
        if (check!=null)
        {
            throw new Exception($"User: {dto.Username} already created a post with title: {dto.Title}!");
        }
        Post post = new Post(dto.Username, dto.Title, dto.Body);
        
        Post create= await _postDao.CreateAsync(post);
        return create;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto)
    {
        return await _postDao.GrtAsync(dto);
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? post = await _postDao.GetByIdAsync(id);
        if (post==null)
        {
            throw new Exception($"Todo with id {id} not found");
        }

        return post;
    }
}