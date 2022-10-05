using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[Controller]")]

public class PostsController:ControllerBase
{
    private readonly IPostLogic _postLogic;

    public PostsController(IPostLogic postLogic)
    {
        _postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreteAsync([FromBody] PostCreationDto creationDto)
    {
        try
        {
            Post post = await _postLogic.CreateAsync(creationDto);
            return Created($"/Posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);

        }
    }
}