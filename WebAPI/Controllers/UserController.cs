using Application.LogicInterface;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[Controller]")]
public class UserController:ControllerBase
{
    private readonly IUserLogic _userLogic;

    public UserController(IUserLogic userLogic)
    {
        _userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync([FromBody]UserCreationDto dto)
    {
        try
        {
            User? user = await _userLogic.CreateAsync(dto);
            return Created($"/user/{user.UserName}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}