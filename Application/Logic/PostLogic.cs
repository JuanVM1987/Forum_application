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

    public async Task<PostReturnDto> CreateAsync(PostBasicDto dto)
    {
        User? checkUser = await _userDao.GetByUsernameAsync(dto.Username);
        if (checkUser == null)
        {
            throw new Exception($"Username: {dto.Username} was not found.");
        }
            
        
        Post? check = await _postDao.GetByUsernameAndTitle(dto.Username, dto.Title);
        if (check!=null)
        {
            throw new Exception($"User: {dto.Username} already created a post with title: {dto.Title}!");
        }
        Post post = new Post(checkUser, dto.Title, dto.Body)
        {
            Created = DateTime.Now
        };
        Post create= await _postDao.CreateAsync(post);
        PostReturnDto returnDto =
            new PostReturnDto(create.Id, create.Title, create.Body, create.Owner.Username, create.Created);
        return returnDto;
    }

    public async Task<IEnumerable<PostReturnDto>> GetAsync(SearchPostParametersDto dto)
    {
        
        IEnumerable<Post> posts= await _postDao.GrtAsync(dto);
        List<PostReturnDto> returnDtos = new List<PostReturnDto>();
        
        foreach (var post in posts)
        {
            returnDtos.Add(new PostReturnDto(post.Id,post.Title,post.Body,post.Owner.Username,post.Created));
        }

        return returnDtos.AsEnumerable();
    }

    public async Task<PostReturnDto?> GetByIdAsync(int id)
    {
        Post? post = await _postDao.GetByIdAsync(id);
        if (post==null)
        {
            throw new Exception($"Todo with id {id} not found");
        }
        PostReturnDto returnDto = new PostReturnDto(post.Id, post.Title, post.Body, post.Owner.Username, post.Created);
        return returnDto;
    }
}