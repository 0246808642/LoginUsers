using AutoMapper;
using LoginUsers.Data;
using LoginUsers.Data.Dtos.UserDtos;
using LoginUsers.Models;
using LoginUsers.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Post([FromBody] CreateUserDto create)
    {
        try
        {
             await _userService.RegisterAsync(create);
            return Ok($"{create.Username} cadastrado com sucesso");
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
     var token = await _userService.Login(dto);
        return Ok(token);
    }

}
