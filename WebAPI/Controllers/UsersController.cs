using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[Controller]")]
public class UsersController:ControllerBase
{
    private readonly IUserLogic _userLogic;

    public UsersController(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync([FromBody]UserCreationDto dto)
    {
        try
        {
            User? user = await _userLogic.CreateAsync(dto);
            return Created($"/user/{user.Username}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserBasicDto>>> Get([FromQuery] string? username)
    {
        try
        {
            SearchUserParametersDto parametersDto = new(username);
            var users = await _userLogic.GetAsync(parametersDto);
            
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}